using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Common
{
  public static  class Constant
    {
        public const string NotEhoughFuelExcMsg
            = "{0} needs refueling";

        public const string InvalidVehicleType
           = "Invalid vehicle";

        public const string InsufficientTankExcMsg
          = "Cannot fit {0} fuel in the tank";

        public const string InvalidFuelExcMsg
         = "Fuel must be a positive number";

        public const string DriveSuccVehicleMsg
           = "{0} travelled {1} km";
    }
}
