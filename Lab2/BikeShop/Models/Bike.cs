namespace BikeShop.Models
{
    public abstract class Bike
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public abstract string GetSpecifications();
    }
}
