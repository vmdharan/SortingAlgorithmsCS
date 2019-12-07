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
        private const int MAXITEMS = 25;  // Maximum number of elements in array

        private static SortableItem<Car>[] vehicles;

        private enum SortingAlgorithm
        {
            BubbleSort = 1,
            SelectionSort = 2,
            InsertionSort = 3,
            MergeSort = 4
        };


        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            Console.WriteLine("-- Before sorting --");
            Initialise();
            ShowData();

            // Run sorting algorithm.
            sw.Start();
            PerformSort();
            //PerformSortMultiThreaded();
            sw.Stop();
            Console.WriteLine("\n -- Total Sorting time: " + sw.Elapsed.TotalMilliseconds + " --");

            Console.WriteLine("\n-- After sorting --");
            ShowData();

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
            //RunSortAlgorithm(vehicles.Clone(), SortingAlgorithm.BubbleSort);
            //RunSortAlgorithm(vehicles.Clone(), SortingAlgorithm.SelectionSort);
            //RunSortAlgorithm(vehicles.Clone(), SortingAlgorithm.InsertionSort);
            RunSortAlgorithm(vehicles, SortingAlgorithm.MergeSort);
        }

        private static void PerformSortMultiThreaded()
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(RunBubbleSort));
            t1.Start(vehicles.Clone());

            Thread t2 = new Thread(new ParameterizedThreadStart(RunSelectionSort));
            t2.Start(vehicles.Clone());

            Thread t3 = new Thread(new ParameterizedThreadStart(RunInsertionSort));
            t3.Start(vehicles.Clone());

            Thread t4 = new Thread(new ParameterizedThreadStart(RunMergeSort));
            t4.Start(vehicles.Clone());

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
        }

        private static void RunSortAlgorithm(Object o, SortingAlgorithm alg)
        {
            var vehicles = (SortableItem<Car>[])o;
            Stopwatch sw = new Stopwatch();

            string algorithm = "Unknown";
            SortingAlgorithm<SortableItem<Car>, Car> s1 = null;

            switch(alg)
            {
                case SortingAlgorithm.BubbleSort:
                    algorithm = "BubbleSort";
                    s1 = new BubbleSort<Car>();
                    break;

                case SortingAlgorithm.SelectionSort:
                    algorithm = "SelectionSort";
                    s1 = new SelectionSort<Car>();
                    break;

                case SortingAlgorithm.InsertionSort:
                    algorithm = "InsertionSort";
                    s1 = new InsertionSort<Car>();
                    break;

                case SortingAlgorithm.MergeSort:
                    algorithm = "MergeSort";
                    s1 = new MergeSort<Car>();
                    break;

                default:
                    break;
            }

            if(s1 != null)
            {
                sw.Start();
                s1.Sort(ref vehicles);
                sw.Stop();
            }

            ShowElapsedTime(sw.Elapsed.TotalMilliseconds, algorithm);
        }

        private static void RunBubbleSort(Object o)
        {
            RunSortAlgorithm(o, SortingAlgorithm.BubbleSort);
        }

        private static void RunSelectionSort(Object o)
        {
            RunSortAlgorithm(o, SortingAlgorithm.SelectionSort);
        }

        private static void RunInsertionSort(Object o)
        {
            RunSortAlgorithm(o, SortingAlgorithm.InsertionSort);
        }

        private static void RunMergeSort(Object o)
        {
            RunSortAlgorithm(o, SortingAlgorithm.MergeSort);
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
