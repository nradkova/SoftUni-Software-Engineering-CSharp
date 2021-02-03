using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
   public class Car
    {
        public Car(string model)
        {
            Model = model;
            Engine = null;
            Weight = "n/a";
            Color = "n/a";
        }
        public string  Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

    }
}
