using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;

namespace Vehicles.Models
{
    public class Bus : Vehicle

    {
        private const double FUEL_COEFFICIENT = 1.4;
        private double fuelConsumption;

        public Bus(double fuelQuantity
            , double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public override double FuelConsumption
        => base.FuelConsumption + FUEL_COEFFICIENT;

        public override string Drive(double km)
        {
            return base.Drive(km);
        }

        public override string DriveEmpty(double km)
        {
            double fuelNeeded = (FuelConsumption-FUEL_COEFFICIENT) * km;
            if (FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException
                    (string.Format(Common.Constant.NotEhoughFuelExcMsg
                    , this.GetType().Name));
            }
            FuelQuantity -= fuelNeeded;
            return string.Format(Common.Constant.DriveSuccVehicleMsg, this.GetType().Name, km);
        }
    }
}
