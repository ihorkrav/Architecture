using BikeShop.Factories;
using BikeShop.Models;
using System.Collections.Generic;
using BikeShop.Data;
namespace BikeShop.Facade
{
    public class BikeShopFacade
    {
        private readonly AppDbContext _context;

        public BikeShopFacade(AppDbContext context)
        {
            _context = context;
        }

        public void AddBike(string type)
        {
            var bike = BikeFactory.CreateBike(type);
            if (bike != null)
            {
                var bikeEntity = new BikeEntity
                {
                    Id = bike.Id,
                    Model = bike.Model,
                    Type = type,
                    Price = bike.Price
                };
               
                _context.Bikes.Add(bikeEntity);
                _context.SaveChanges();
            }
        }

        public List<BikeEntity> GetAvailableBikes()
        {
            return _context.Bikes.ToList();
        }

        public void PlaceOrder(string CustomerName, int bikeId)
        {
            var order = new Order
            {
                CustomerName = CustomerName,
                BikeId = bikeId
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        

    }
}
