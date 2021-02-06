using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;
using Vehicles.Common;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double FUEL_COEFFICIENT = 0.9;

        public Car(double fuelQuantity
            , double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption 
            => base.FuelConsumption + FUEL_COEFFICIENT;
        
       
    }
}
