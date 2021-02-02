using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
   public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car(string model)
        {
            Model = model;
            Engine = new Engine();
            Cargo = new Cargo();
            Tires = new Tire[4];
        }

        public string  Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }
    }
}
