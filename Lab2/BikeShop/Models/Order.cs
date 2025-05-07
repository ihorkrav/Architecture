using System;
using BikeShop.Models;

namespace BikeShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public int BikeId { get; set; }            
        public BikeEntity Bike { get; set; }         
    }
}
