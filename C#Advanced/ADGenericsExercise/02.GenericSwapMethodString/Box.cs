using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T>
    {
        public T Value { get; set; }

        public override string ToString()
        {
            string result = $"{this.Value.GetType()}: {this.Value}";
            return result;
        }
    }
}
