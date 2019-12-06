using SortingAlgorithmsCS.Algorithms;
using SortingAlgorithmsCS.Classes;
using SortingAlgorithmsCS.Patterns;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
            //PerformSort();
            PerformSortMultiThreaded();
            sw.Stop();
            Console.WriteLine("\n -- Total Sorting time: " + sw.Elapsed.TotalMilliseconds + " --");

            Console.WriteLine("\n-- After sorting --");
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
            RunSelectionSort(vehicles);
            RunBubbleSort(vehicles);
        }

        private static void PerformSortMultiThreaded()
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(RunBubbleSort));
            t1.Start(vehicles);

            Thread t2 = new Thread(new ParameterizedThreadStart(RunSelectionSort));
            t2.Start(vehicles);

            t1.Join();
            t2.Join();
        }

        private static void RunBubbleSort(Object o)
        {
            var vehicles = (SortableItem<Car>[])o;
            Stopwatch sw = new Stopwatch();
            var s1 = new BubbleSort<Car>();

            sw.Start();
            s1.Sort(ref vehicles);
            sw.Stop();

            ShowElapsedTime(sw.Elapsed.TotalMilliseconds, "BubbleSort");
        }

        private static void RunSelectionSort(Object o)
        {
            var vehicles = (SortableItem<Car>[])o;
            Stopwatch sw = new Stopwatch();
            var s1 = new SelectionSort<Car>();

            sw.Start();
            s1.Sort(ref vehicles);
            sw.Stop();

            ShowElapsedTime(sw.Elapsed.TotalMilliseconds, "SelectionSort");
        }

        private static void ShowElapsedTime(double t, string sortType)
        {
            Console.WriteLine("\n-- Elapsed time(ms) for " + sortType + " --");
            Console.WriteLine(t);
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
