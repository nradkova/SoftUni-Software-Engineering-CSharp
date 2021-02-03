using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }

        public int Count
        {
            get
            {
                return Count = cars.Count;
            }
            set { }
        }

        public string AddCar(Car car)
        {
            if (cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }
            else if (cars.Count == capacity)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string number)
        {
            if (cars.Any(x => x.RegistrationNumber == number))
            {
                Car car = cars.FirstOrDefault(x => x.RegistrationNumber == number);
                cars.Remove(car);
                return $"Successfully removed {number}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string number)
        {
            if (cars.Any(x => x.RegistrationNumber == number))
            {
                Car car = cars.FirstOrDefault(x => x.RegistrationNumber == number);
                return car;
            }
            return null;
        }
        public void RemoveSetOfRegistrationNumber(List<string> numbers)
        {
            foreach (var number in numbers)
            {
                if (cars.Any(x => x.RegistrationNumber == number))
                {
                    Car car = cars.FirstOrDefault(x => x.RegistrationNumber == number);
                    cars.Remove(car);
                }
            }
        }
    }
}
