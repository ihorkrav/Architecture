using Microsoft.EntityFrameworkCore;
using BikeShop.Models;

namespace BikeShop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
       
        public DbSet<User> Users { get; set; }
        public DbSet<BikeEntity> Bikes { get; set; }
        public DbSet<Order> Orders { get; set; } // ✅ Add this line
        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Ignore<Bike>(); // ✅ Tell EF to ignore the abstract Bike class
}
    }
}
