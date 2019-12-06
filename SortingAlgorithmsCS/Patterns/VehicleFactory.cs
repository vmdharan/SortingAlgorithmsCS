using SortingAlgorithmsCS.Classes;
using System;


namespace SortingAlgorithmsCS.Patterns
{
    class VehicleFactory<T> where T : Vehicle
    {
        private static Random random;
        private int min;
        private int max;

        private const int MaxMakes = 5;
        private const int MaxModels = 6;

        private readonly string[] VehicleMakes = {
            "Make1", "Make2", "Make3", "Make4", "Make5"
        };

        private readonly string[] VehicleModels = {
            "Model1", "Model2", "Model3", "Model4", "Model5", "Model6"
        };


        public VehicleFactory(int _min, int _max)
        {
            random = new Random();
            min = _min;
            max = _max;
        }

        public SortableItem<Car> CreateCar()
        {
            SortableItem<Car> vehicle;
            vehicle = new SortableItem<Car>();
            vehicle.Id = random.Next(min, max);

            vehicle.Val = new Car();
            vehicle.Val.make = VehicleMakes[(random.Next(min, max) % MaxMakes)];
            vehicle.Val.model = VehicleModels[(random.Next(min, max) % MaxModels)];
            vehicle.Val.registration = "REG" + Convert.ToString(vehicle.Id).PadLeft(8, '0');

            return vehicle;
        }

        // TO DO
        public SortableItem<T> CreateTruck()
        {
            SortableItem<T> vehicle;
            vehicle = new SortableItem<T>();

            return vehicle;
        }

        // TO DO
        public SortableItem<T> CreateBike()
        {
            SortableItem<T> vehicle;
            vehicle = new SortableItem<T>();

            return vehicle;
        }
    }
}
