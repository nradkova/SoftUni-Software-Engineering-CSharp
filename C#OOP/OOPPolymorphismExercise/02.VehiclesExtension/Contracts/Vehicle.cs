using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;

namespace Vehicles.Contracts
{
    public abstract class Vehicle
    {
        //private const string DRIVE_SUCC_VEHICLE_MSG
        //    = "{0} travelled {1} km";
        private double tankCapacity;

        protected Vehicle(double fuelQuantity
            , double fuelConsumption, double tankCapacity)
        {
            FuelConsumption = fuelConsumption;
            FuelQuantity = fuelQuantity;
            TankCapacity = tankCapacity;
        }
        public double FuelQuantity { get; set; }

        public virtual double FuelConsumption { get; set; }

        public double TankCapacity
        {
            get
            {
                return tankCapacity;
            }
            private set
            {
                if (value < FuelQuantity)
                {
                    FuelQuantity = 0;
                }
                tankCapacity = value;
            }
        }

        public virtual string Drive(double km)
        {
            if (FuelQuantity < (FuelConsumption * km))
            {
                throw new InvalidOperationException
                    (string.Format(Common.Constant.NotEhoughFuelExcMsg
                    , this.GetType().Name));
            }
            FuelQuantity -= FuelConsumption * km;
            return string.Format(Common.Constant.DriveSuccVehicleMsg, this.GetType().Name, km);
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new InvalidOperationException
                    (string.Format(Constant.InvalidFuelExcMsg));
            }
            if (liters + FuelQuantity > TankCapacity)
            {
                throw new InvalidOperationException
                    (string.Format(Constant.InsufficientTankExcMsg, liters));
            }
            else
            {
                FuelQuantity += liters;
            }
        }
        public virtual string DriveEmpty(double km)
        {
            double fuelNeeded = FuelConsumption * km;
            if (FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException
                    (string.Format(Common.Constant.NotEhoughFuelExcMsg
                    , this.GetType().Name));
            }
            FuelQuantity -= fuelNeeded;
            return string.Format(Common.Constant.DriveSuccVehicleMsg, this.GetType().Name, km);
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
