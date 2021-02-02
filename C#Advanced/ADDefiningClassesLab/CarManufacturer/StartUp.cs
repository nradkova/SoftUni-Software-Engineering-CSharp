using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            List<Tire[]> tiresList = new List<Tire[]>();
            while ((command = Console.ReadLine()) != "No more tires")
            {
                string[] tokens = command.Split();
                Tire[] tires = new Tire[4]
                {
                new Tire(int.Parse(tokens[0]),double.Parse(tokens[1])),
                new Tire(int.Parse(tokens[2]),double.Parse(tokens[3])),
                new Tire(int.Parse(tokens[4]),double.Parse(tokens[5])),
                new Tire(int.Parse(tokens[6]),double.Parse(tokens[7])),
                };
                tiresList.Add(tires);
            }

            List<Engine> engineList = new List<Engine>();
            while ((command = Console.ReadLine()) != "Engines done")
            {
                string[] tokens = command.Split();
                Engine engine=new Engine(int.Parse(tokens[0]),double.Parse(tokens[1]));
                engineList.Add(engine);
            }
            List<Car> carList = new List<Car>();
            while ((command = Console.ReadLine()) != "Show special")
            {
                string[] tokens = command.Split();
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption);
                car.Engine = engineList[int.Parse(tokens[5])];
                car.Tires = tiresList[int.Parse(tokens[6])];
                carList.Add(car);
            }
            carList = carList.Where(car => car.Year >= 2017 
            && car.Engine.HorsePower>330
            && car.Tires.Sum(x=>x.Pressure)>=9
            && car.Tires.Sum(x => x.Pressure) <=10).ToList();
            foreach (var car in carList)
            {
                car.Drive(20);
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");

            }

        }
    }
}
