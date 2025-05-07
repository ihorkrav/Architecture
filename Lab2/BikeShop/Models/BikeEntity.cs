// Models/BikeEntity.cs
namespace BikeShop.Models
{
    public class BikeEntity
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Type { get; set; } // like "mountain", "road", etc.
        public decimal Price { get; set; }
    }
}
