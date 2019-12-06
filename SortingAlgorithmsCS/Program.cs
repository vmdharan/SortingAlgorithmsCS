using SortingAlgorithmsCS.Algorithms;
using SortingAlgorithmsCS.Classes;
using SortingAlgorithmsCS.Patterns;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmsCS
{
    class Program
    {
        private const int MAXINDEX = 99999;  // Maximum value to use as index (for RNG)
        private const int MAXITEMS = 20000;  // Maximum number of elements in array
        private static SortableItem<Car>[] vehicles;

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            Console.WriteLine("-- Before sorting --");
            Initialise();
            //ShowData();

            // Run sorting algorithm.
            sw.Start();
            PerformSort();
            sw.Stop();
            Console.WriteLine("\n-- Elapsed time(ms) for sort --");
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);

            Console.WriteLine("\n-- After sorting -- ");
            //ShowData();

            Console.ReadKey();
        }

        private static void Initialise()
        {
            Random rnd = new Random();
            vehicles = new SortableItem<Car>[MAXITEMS];

            VehicleFactory<Car> vehicleFactory = new VehicleFactory<Car>(0, MAXINDEX);
            for (int i = 0; i < MAXITEMS; i++)
            {
                vehicles[i] = vehicleFactory.CreateCar();
            }
        }

        private static void PerformSort()
        {
            //var s1 = new BubbleSort<Car>();
            var s1 = new SelectionSort<Car>();
            s1.Sort(ref vehicles);

            
        }

        private static void ShowData()
        {
            for (int i = 0; i < MAXITEMS; i++)
            {
                Console.WriteLine(vehicles[i].Id + ", " + vehicles[i].Val.registration + ", " 
                    + vehicles[i].Val.make + ", " + vehicles[i].Val.model);
            }
        }
    }
}
