using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Parking
{
    public class Parking 
    {
        private List<Car> cars;
        public Parking(string type, int capacity)
        {
            Capacity = capacity;
            Type = type;
            cars = new List<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return cars.Count;
            }
            set { }
        }

        public void Add(Car car)
        {
            if (cars.Count < Capacity)
            {
                cars.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            var car = cars.FirstOrDefault
                (x => x.Manufacturer == manufacturer && x.Model == model);
            if (car != null)
            {
                cars.Remove(car);
                return true;
            }
            return false;
        }
        public Car GetCar(string manufacturer, string model)
        {
            var car = cars.FirstOrDefault
                (x => x.Manufacturer == manufacturer && x.Model == model);
            if (car != null)
            {
                return car;
            }
            return null;
        }
        public Car GetLatestCar()
        {
            if (cars.Count == 0)
            {
                return null;

            }
            cars = cars.OrderBy(x => x.Year).ToList();

            return cars[cars.Count - 1];
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            if (cars.Count > 0)
            {
                sb.AppendLine( $"The cars are parked in {Type}:");
                foreach (var car in cars)
                {
                   sb.AppendLine( car.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }

    }
}
