using Microsoft.AspNetCore.Mvc;
using BikeShop.Facade;
using BikeShop.Models;
using BikeShop.Data;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Controllers
{
    public class BikeController : Controller
    {
        private readonly BikeShopFacade _bikeShop;
        private readonly AppDbContext _context;
        private readonly BikeShopFacade _facade;



        public BikeController(AppDbContext context, BikeShopFacade bikeShop, BikeShopFacade facade)
        {
            _facade = facade;
            _context = context;
            _bikeShop = bikeShop;
        }


public IActionResult Index()
{
    _context.Database.EnsureCreated();

    // Add bikes if none exist
    if (!_context.Bikes.Any())
    {
        _context.Bikes.AddRange(
            new BikeEntity { Model = "Mountain Bike X200", Type = "Mountain", Price = 599.99M },
            new BikeEntity { Model = "Road Runner 3000", Type = "Road", Price = 799.99M },
            new BikeEntity { Model = "Urban Commuter", Type = "Road", Price = 399.99M },
            new BikeEntity { Model = "Trail Blazer", Type = "Mountain", Price = 899.99M },
            new BikeEntity { Model = "Speedster Pro", Type = "Road", Price = 999.99M },
            new BikeEntity { Model = "City Cruiser", Type = "Hybrid", Price = 649.99M },
            new BikeEntity { Model = "VoltRide E-Bike", Type = "Electric", Price = 1499.99M },
            new BikeEntity { Model = "Eco Hybrid 360", Type = "Hybrid", Price = 749.99M },
            new BikeEntity { Model = "BMX Stunt Master", Type = "BMX", Price = 529.99M },
            new BikeEntity { Model = "Hill Climber Pro", Type = "Mountain", Price = 1099.99M },
            new BikeEntity { Model = "Urban Glide E-Bike", Type = "Electric", Price = 1399.99M }
        );

        _context.SaveChanges();
    }
    var bikes = _bikeShop.GetAvailableBikes(); 
    return View(bikes);
}

       

       public IActionResult Order(string model)
{
    ViewBag.Model = model;
    return View();
}

[HttpPost]
public IActionResult PlaceOrder(string Username, string model)
{
    var bike = _context.Bikes.FirstOrDefault(b => b.Model == model);
    if (bike == null)
        return NotFound("Bike not found");

    _facade.PlaceOrder(Username, bike.Id);

    var order = _context.Orders
        .Include(o => o.Bike)
        .OrderByDescending(o => o.Id)
        .FirstOrDefault(o => o.CustomerName == Username && o.BikeId == bike.Id);

    if (order == null)
    {
        order = new Order
        {
            CustomerName = Username,
            Bike = bike
        };
    }

    return View("OrderConfirm", order);
}

    
            public IActionResult OrderConfirm(int orderId)
            {
                var order = _context.Orders
                    .Include(o => o.Bike)
                    .FirstOrDefault(o => o.Id == orderId);
    
                if (order == null)
                {
                    return NotFound("Order not found");
                }
    
                return View(order);
            }
    }
}
