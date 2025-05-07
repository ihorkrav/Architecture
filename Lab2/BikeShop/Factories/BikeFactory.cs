using BikeShop.Models;

namespace BikeShop.Factories
{
    public static class BikeFactory
    {
        public static Bike CreateBike(string type)
        {
            return type switch
            {
                "mountain" => new MountainBike(),
                "road" => new RoadBike(),
                "hybrid" => new HybridBike(),
                "electric" => new ElectricBike(),
                "bmx" => new BMXBike(),
                _ => null
            };
        }
    }
}
