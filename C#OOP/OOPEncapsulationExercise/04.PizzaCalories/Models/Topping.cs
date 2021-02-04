using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using _04.PizzaMake.Common;

namespace _04.PizzaMake.Models
{
   public class Topping
    {
        private string toppingType;
        private double weight;
        private double defaultModifier = 2;
        public Topping(string topping, double weight)
        {
            ToppingType = topping;
            Weight = weight;
        }
        
        public string ToppingType
        {
            get { return toppingType; }
            set
            {
                string input = value;
                value = value.ToLower();
                if (value!= "meat"&&value!="veggies"
                    &&value !="cheese"&&value!="sauce")
                {
                    throw new ArgumentException(string.Format( Constants.INVALID_TOPPING_TYPE_MSG,input));
                }
                toppingType = input; 
            }
        }
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value <1|| value >50)
                {
                    throw new ArgumentException
                        (string.Format( Constants.INVALID_TOPPING_WEIGHT_MSG,ToppingType));
                }
                weight = value;
            }
        }
        public double CalculateCalories()
        {
            double modifier = 0;

            switch (ToppingType.ToLower())
            {
                case "meat":
                    modifier = 1.2;
                    break;
                case "veggies":
                    modifier = 0.8;
                    break;
                case "cheese":
                    modifier = 1.1;
                    break;
                case "sauce":
                    modifier = 0.9;
                    break;
            }
            return Weight * defaultModifier * modifier ;
        }
    }
}
