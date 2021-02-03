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
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);

                Car car = new Car(model);
                car.Engine.Speed = engineSpeed;
                car.Engine.Power = enginePower;
                car.Cargo.Weight = cargoWeight;
                car.Cargo.Type = cargoType;
                
                car.Tires[0] = new Tire(tire1Pressure, tire1Age);
                car.Tires[1] = new Tire(tire2Pressure, tire2Age);
                car.Tires[2] = new Tire(tire3Pressure, tire3Age);
                car.Tires[3] = new Tire(tire4Pressure, tire4Age);

                cars.Add(car);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                cars = cars
                    .Where(car => car.Cargo.Type == command)
                    .Where(car => car.Tires.Any(x => x.Pressure < 1))
                    .ToList();
            }
            else if (command == "flamable")
            {
                cars = cars
                    .Where(car => car.Cargo.Type == command)
                    .Where(car => car.Engine.Power > 250)
                    .ToList();
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}");
            }
        }
    }
}
