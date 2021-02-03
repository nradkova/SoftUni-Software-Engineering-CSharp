using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Cargo
    {
        private string type;
        private int weight;
       
        public Cargo()
        {
            Type = type;
            Weight = weight;
        }

        public string Type { get; set; }
        public int Weight { get; set; }
    }
}
