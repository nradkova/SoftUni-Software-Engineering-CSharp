using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaMake.Common
{
  public static class Constants
    {
        public const  string INVALID_DOUGH_TYPE_MSG 
            = "Invalid type of dough.";
        public const  string INVALID_DOUGH_WEIGHT_MSG 
            ="Dough weight should be in the range [1..200].";
        public const string INVALID_TOPPING_TYPE_MSG
           = "Cannot place {0} on top of your pizza.";
        public const string INVALID_TOPPING_WEIGHT_MSG
           = "{0} weight should be in the range [1..50].";
        public const string INVALID_NAME_LEN_MSG
            = "Pizza name should be between 1 and 15 symbols.";
        public const string INVALID_TOPPINGS_NUM_MSG
            = "Number of toppings should be in range [0..10].";
    }
}
