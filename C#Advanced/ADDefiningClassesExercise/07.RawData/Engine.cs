using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
   public class Engine
    {
        private int speed;
        private int power;

        public Engine()
        {
            Speed = speed;
            Power = power;
        }
        public int Speed { get; set; }
        public int Power { get; set; }

    }
}
