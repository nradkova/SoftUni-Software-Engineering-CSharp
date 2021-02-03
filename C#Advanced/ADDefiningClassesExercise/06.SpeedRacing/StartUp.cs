using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double amount = double.Parse(input[1]);
                double consumption = double.Parse(input[2]);
                cars.Add(new Car(model, amount, consumption));
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                Drive(cars, command.Split()[1], int.Parse(command.Split()[2]));
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }

        }

        static void Drive(List<Car> cars, string model, int km)
        {
            foreach (var car in cars)
            {
                if (car.Model == model)
                {
                    double consumption = km * car.FuelConsumption;
                    if (consumption <= car.FuelAmount)
                    {
                        car.FuelAmount -= consumption;
                        car.TravelledDistance += km;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }
                }
            }
        }
    }
}
