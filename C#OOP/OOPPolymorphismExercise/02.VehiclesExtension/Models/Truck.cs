using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;
using Vehicles.Contracts;

namespace Vehicles.Models
{
    public class Truck:Vehicle
    {
        private const double FUEL_COEFFICIENT = 1.6;
        private const double FUEL_LEAKAGE_COEFFICIENT =0.05;

        public Truck(double fuelQuantity
            , double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption
            => base.FuelConsumption + FUEL_COEFFICIENT;

        public override void Refuel(double liters)
        {
           double truckLiters= liters * (1 - FUEL_LEAKAGE_COEFFICIENT);
            base.Refuel(truckLiters);
        }
       
    }
}
