using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> cars = new HashSet<string>();
            while ((input=Console.ReadLine())!="END")
            {
                string[] data = input.Split(", ");
                if (data[0]=="IN")
                {
                    cars.Add(data[1]);
                }
                else
                {
                    if (cars.Contains(data[1]))
                    {
                        cars.Remove(data[1]);
                    }
                }
            }
            if (cars.Count==0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine,cars));
            }
        }
    }
}
