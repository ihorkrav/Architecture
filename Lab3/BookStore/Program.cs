using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BookStore.Core.Ports;
using BookStore.Core.Services;
using BookStore.Infrastructure.Adapters;
using BookStore.Infrastructure.Repositories;
using BookStore.Core.Entities;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<IBookRepository, EfBookRepository>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<IOrderRepository, EfOrderRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=BookStore.db"));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));




var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated(); // simpler for now
}
// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Serve static files (e.g., CSS, JS)

app.UseSession();
app.UseRouting();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();

    if (!db.Books.Any())
    {
        db.Books.AddRange(new List<Book>
        {
            new Book { Title = "1984", Price = 9.99m },
            new Book { Title = "Brave New World", Price = 10.49m },
            new Book { Title = "Fahrenheit 451", Price = 8.99m },
            new Book { Title = "The Great Gatsby", Price = 7.99m },
            new Book { Title = "Moby Dick", Price = 11.49m },
            new Book { Title = "War and Peace", Price = 12.99m },
            new Book { Title = "Pride and Prejudice", Price = 6.99m },
            new Book { Title = "To Kill a Mockingbird", Price = 9.49m },
            new Book { Title = "The Catcher in the Rye", Price = 10.29m },
            new Book { Title = "The Hobbit", Price = 8.59m },
            new Book { Title = "Dune", Price = 14.99m },
            new Book { Title = "Crime and Punishment", Price = 11.79m },
            new Book { Title = "Dracula", Price = 7.49m },
            new Book { Title = "The Picture of Dorian Gray", Price = 6.49m },
            new Book { Title = "Frankenstein", Price = 5.99m },
        });

        db.SaveChanges();
    }
}


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Default route to login

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    var users = context.Users.ToList();
    var books = context.Books.ToList();
    var orders = context.Orders
        .Include(o => o.Book)
        .Include(o => o.User)
        .ToList();

    Console.WriteLine("\n=== USERS ===");
    foreach (var user in users)
        Console.WriteLine($"Id: {user.Id}, Username: {user.Username}");

    Console.WriteLine("\n=== BOOKS ===");
    foreach (var book in books)
        Console.WriteLine($"Id: {book.Id}, Title: {book.Title}, Price: {book.Price}");

    Console.WriteLine("\n=== ORDERS ===");
    foreach (var order in orders)
        Console.WriteLine($"Order Id: {order.Id}, User: {order.User.Username}, Book: {order.Book.Title}");
}


app.Run();

