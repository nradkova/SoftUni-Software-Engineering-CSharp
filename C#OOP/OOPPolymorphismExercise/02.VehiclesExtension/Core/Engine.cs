using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;
using Vehicles.Core.Contract;
using Vehicles.Factories;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly VehicleFactory vehicleFactory;
        private readonly ICollection<Vehicle> vehicles;
        public Engine()
        {
            vehicleFactory = new VehicleFactory();
            vehicles = new List<Vehicle>();
        }
        public void Run()
        {
            for (int i = 0; i < 3; i++)
            {
                Vehicle vehicle = ReadVehicleInfo();
                vehicles.Add(vehicle);
            }
            int n = int.Parse(Console.ReadLine());
            while (n > 0)
            {
                string[] command = Console.ReadLine().Split();
                try
                {
                    DriveVehicle(command);
                    RefuelVehicle(command);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                n--;
            }
            PrintVehicle();
        }

        private Vehicle ReadVehicleInfo()
        {
            string[] input = Console.ReadLine().Split();
            double fuelQuantity = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);
            double tankCapacity = double.Parse(input[3]);
           
            Vehicle vehicle = this.vehicleFactory
                .CreateVehicle(input[0], fuelQuantity
                , fuelConsumption, tankCapacity);
            return vehicle;
        }

        private void PrintVehicle()
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        private void RefuelVehicle(string[] command)
        {
            if (command[0] == "Refuel")
            {
                foreach (var vehicle in vehicles)
                {
                    if (vehicle.GetType().Name == command[1])
                    {
                        vehicle.Refuel(double.Parse(command[2]));
                    }
                }
            }
        }

        private void DriveVehicle(string[] command)
        {
            if (command[0] == "Drive")
            {
                foreach (var vehicle in vehicles)
                {
                    if (vehicle.GetType().Name == command[1])
                    {
                        Console.WriteLine(vehicle.Drive(double.Parse(command[2])));
                    }
                }
            }
            if (command[0] == "DriveEmpty")
            {
                foreach (var vehicle in vehicles)
                {
                    if (vehicle.GetType().Name == command[1])
                    {
                        Console.WriteLine(((Bus)vehicle).DriveEmpty(double.Parse(command[2])));
                    }
                }
            }
        }
    }
}

