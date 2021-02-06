using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;
using Vehicles.Contracts;
using Vehicles.Models;

namespace Vehicles.Factories
{
    public class VehicleFactory
    {
        public VehicleFactory()
        {

        }
        public Vehicle CreateVehicle(string vehicleType
            , double fuelQuantity, double fuelConsumption
            ,double tankCapacity)
        {
            Vehicle vehicle = null;
            if (vehicleType == "Car")
            {
                vehicle = new Car
                    (fuelQuantity, fuelConsumption, tankCapacity);
            }
           else if (vehicleType == "Truck")
            {
                vehicle = new Truck
                    (fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Bus")
            {
                vehicle = new Bus
                    (fuelQuantity, fuelConsumption, tankCapacity);
            }
            else
            {
                throw new InvalidOperationException
                    (Constant.InvalidVehicleType);
            }

            return vehicle;
        }
    }
}
