using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;

namespace Vehicles.Models
{
    public class Truck:Vehicle
    {
        private const double summerFuelCoefficient = 1.6;
        private const double fuelLeakageCoefficient =0.05;

        public Truck(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public override string Drive(double km)
        {
            if (FuelQuantity < (FuelConsumption + summerFuelCoefficient) * km)
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
            FuelQuantity += liters*(1-fuelLeakageCoefficient);
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
