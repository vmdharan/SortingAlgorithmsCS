using SortingAlgorithmsCS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmsCS
{
    class Program
    {
        private const int MAXVAL = 10;
        private static SortableItem<Car>[] vehicles;

        static void Main(string[] args)
        {
            Console.WriteLine("-- Before sorting --");
            Initialise();
            ShowData();

            Console.WriteLine("\n-- After sorting -- ");

            Console.ReadKey();
        }

        private static void Initialise()
        {
            Random rnd = new Random();
            vehicles = new SortableItem<Car>[MAXVAL];

            for (int i = 0; i < MAXVAL; i++)
            {
                vehicles[i] = new SortableItem<Car>();
                vehicles[i].Id = rnd.Next(1, 101);
            }
            vehicles[0].Val = new Car("Ford", "Falcon", "REG0" + Convert.ToString(0).PadLeft(2, '0'));
            vehicles[1].Val = new Car("Ford", "Mondeo", "REG0" + Convert.ToString(1).PadLeft(2, '0'));
            vehicles[2].Val = new Car("Holden", "Commodore", "REG0" + Convert.ToString(2).PadLeft(2, '0'));
            vehicles[3].Val = new Car("Toyota", "Aurion", "REG0" + Convert.ToString(3).PadLeft(2, '0'));
            vehicles[4].Val = new Car("Toyota", "Camry", "REG0" + Convert.ToString(4).PadLeft(2, '0'));
            vehicles[5].Val = new Car("Honda", "Accord", "REG0" + Convert.ToString(5).PadLeft(2, '0'));
            vehicles[6].Val = new Car("Hyundai", "i30", "REG0" + Convert.ToString(6).PadLeft(2, '0'));
            vehicles[7].Val = new Car("Mitsubishi", "Lancer", "REG0" + Convert.ToString(7).PadLeft(2, '0'));
            vehicles[8].Val = new Car("Mazda", "3", "REG0" + Convert.ToString(8).PadLeft(2, '0'));
            vehicles[9].Val = new Car("Ford", "Mustang", "REG0" + Convert.ToString(9).PadLeft(2, '0'));
        }

        private static void ShowData()
        {
            for (int i = 0; i < MAXVAL; i++)
            {
                Console.WriteLine(vehicles[i].Id + ", " + vehicles[i].Val.registration + ", " 
                    + vehicles[i].Val.make + ", " + vehicles[i].Val.model);
            }
        }
    }
}
