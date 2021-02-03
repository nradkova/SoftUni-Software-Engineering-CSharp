using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfEngines =int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" "
                    ,StringSplitOptions.RemoveEmptyEntries);
                Engine engine = new Engine
                    (engineInfo[0], engineInfo[1]);
                FillOneOptionalProp(engineInfo, engine);
                FillTwoOptionalProp(engineInfo, engine);
                engines.Add(engine);
            }

            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i <numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ",
                    StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car(carInfo[0]);
                car.Engine = engines.Find(engine => engine.Model == carInfo[1]);
                FillOneOptionalProp(carInfo, car);
                FillTwoOptionalProp(carInfo, car);
                cars.Add(car);
            }
            foreach (var car in cars)
            {
                Console.WriteLine(PrintFormat(car));
            }
        }

        public static void FillTwoOptionalProp(string[] engineInfo, Engine engine)
        {
            if (engineInfo.Length == 4)
            {
                int number = 0;
                if (int.TryParse(engineInfo[2], out number))
                {
                    engine.Displacement = engineInfo[2];
                    engine.Efficiency = engineInfo[3];
                }
                else
                {
                    engine.Efficiency = engineInfo[2];
                    engine.Displacement = engineInfo[3];
                }
            }
        }
        public static void FillOneOptionalProp(string[] engineInfo, Engine engine)
        {
            if (engineInfo.Length == 3)
            {
                int number = 0;
                if (int.TryParse(engineInfo[2], out number))
                {
                    engine.Displacement = engineInfo[2];
                }
                else
                {
                    engine.Efficiency = engineInfo[2];
                }
            }
        }
        public static void FillOneOptionalProp(string[] carInfo, Car car)
        {
            if (carInfo.Length == 3)
            {
                int number = 0;
                if (int.TryParse(carInfo[2], out number))
                {
                   car.Weight = carInfo[2];
                }
                else
                {
                   car.Color = carInfo[2];
            }
                }
        }
        public static void FillTwoOptionalProp(string[] carInfo, Car car)
        {
            if (carInfo.Length == 4)
            {
                int number = 0;
                if (int.TryParse(carInfo[2], out number))
                {
                    car.Weight = carInfo[2];
                    car.Color = carInfo[3];
                }
                else
                {
                    car.Weight = carInfo[3];
                    car.Color = carInfo[2];
                }
            }
        }

        public static string PrintFormat(Car car)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{car.Model}:");
            sb.AppendLine($"  {car.Engine.Model}:");
            sb.AppendLine($"    Power: {car.Engine.Power}");
            sb.AppendLine($"    Displacement: {car.Engine.Displacement}");
            sb.AppendLine($"    Efficiency: {car.Engine.Efficiency}");
            sb.AppendLine($"  Weight: {car.Weight}");
            sb.AppendLine($"  Color: {car.Color}");
            return sb.ToString().TrimEnd();
        }
    }

}
