using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Contracts
{
   public abstract class Vehicle
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public abstract string  Drive(double km);
        public abstract void Refuel(double liters);

        
    }
}
