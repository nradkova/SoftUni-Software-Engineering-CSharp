using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;
using Vehicles.Common;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double summerFuelCoefficient = 0.9;

        public Car(double fuelQuantity, double fuelConsumption )
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }  
        public override string  Drive(double km)
        {
            if (FuelQuantity<(FuelConsumption+summerFuelCoefficient)*km)
            {
                throw new InvalidOperationException
                    (string.Format(Common.Constant.NOT_ENOUGH_FUEL_EXC_MSG
                    , this.GetType().Name));
            }
            FuelQuantity -= (FuelConsumption + summerFuelCoefficient) * km;
            return $"{this.GetType().Name} travelled {km} km";
        }

        public override void Refuel(double liters)
        {
            FuelQuantity += liters;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
