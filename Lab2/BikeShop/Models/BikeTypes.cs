namespace BikeShop.Models
{
    public class MountainBike : Bike
    {
        public MountainBike()
        {
            Model = "Mountain Bike";
            Price = 1000;
        }

        public override string GetSpecifications()
        {
            return "Durable, good for off-road trails.";
        }
    }

    public class RoadBike : Bike
    {
        public RoadBike()
        {
            Model = "Road Bike";
            Price = 800;
        }

        public override string GetSpecifications()
        {
            return "Lightweight, ideal for speed on pavement.";
        }
    }

    public class HybridBike : Bike
    {
        public HybridBike()
        {
            Model = "Hybrid Bike";
            Price = 700;
        }

        public override string GetSpecifications()
        {
            return "Versatile, good for both city rides and light trails.";
        }
    }

    public class ElectricBike : Bike
    {
        public ElectricBike()
        {
            Model = "Electric Bike";
            Price = 1500;
        }

        public override string GetSpecifications()
        {
            return "Powered by battery, helps with long commutes or hills.";
        }
    }

    public class BMXBike : Bike
    {
        public BMXBike()
        {
            Model = "BMX Bike";
            Price = 500;
        }

        public override string GetSpecifications()
        {
            return "Compact and strong, ideal for tricks and jumps.";
        }
    }
}
