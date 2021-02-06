using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;
using Vehicles.Models;

namespace Vehicles.Core
{
   public  class Engine
    {
        private ICollection<Vehicle> vehicles;
        public Engine()
        {
            vehicles = new List<Vehicle>();
        }
       public void Run()
        {
            for (int i = 0; i < 2; i++)
            {
                string[] input = Console.ReadLine().Split();
                Vehicle vehicle = null;
                vehicle = CreateVehicle(input, vehicle);
            }
            int n = int.Parse(Console.ReadLine());
            while (n > 0)
            {
                string[] command = Console.ReadLine().Split();
                DriveVehicle(command);
                RefuelVehicle(command);
                n--;
            }
            PrintVehicle();
        }

        private Vehicle CreateVehicle(string[] input, Vehicle vehicle)
        {
            if (input[0] == "Car")
            {
                vehicle = new Car
                    (double.Parse(input[1]), double.Parse(input[2]));
            }
            if (input[0] == "Truck")
            {
                vehicle = new Truck
                     (double.Parse(input[1]), double.Parse(input[2]));
            }
            if (vehicle != null)
            {
                vehicles.Add(vehicle);
            }

            return vehicle;
        }

        private void PrintVehicle()
        {
            foreach (var veihicle in vehicles)
            {
                Console.WriteLine(veihicle);
            }
        }

        private void RefuelVehicle(string[] command)
        {
            if (command[0] == "Refuel")
            {
                foreach (var veihicle in vehicles)
                {
                    if (veihicle.GetType().Name == command[1])
                    {
                        veihicle.Refuel(double.Parse(command[2]));
                    }
                }
            }
        }

        private void DriveVehicle(string[] command)
        {
            if (command[0] == "Drive")
            {
                try
                {
                    foreach (var veihicle in vehicles)
                    {
                        if (veihicle.GetType().Name == command[1])
                        {
                            Console.WriteLine(veihicle.Drive(double.Parse(command[2])));
                        }
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }
    }
}
