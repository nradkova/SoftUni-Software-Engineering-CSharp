using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _04.PizzaMake.Common;

namespace _04.PizzaMake.Models
{
    public class Pizza
    {
        private string name;
        private double calories;
        private Dough dough;
        private List<Topping> toppings;
        public Pizza(string name)
        {
            Name = name;
            Toppings = new List<Topping>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException(Constants.INVALID_NAME_LEN_MSG);
                }
                name = value;
            }
        }
        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }
        public double Calories
        {
            get { return calories; }
            set { calories = value; }
        }

        public List<Topping> Toppings
        {
            get { return toppings; }
            private set
            {
                toppings = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (Toppings.Count > 10)
            {
                throw new ArgumentException(Constants.INVALID_TOPPINGS_NUM_MSG);
            }
            Toppings.Add(topping);
        }

        private void CalculateCalories()
        {
            Calories = Dough.CalculateCalories() + Toppings.Sum(t => t.CalculateCalories());
        }
        public override string ToString()
        {
            CalculateCalories();
            return $"{Name} - {Calories:f2} Calories.";
        }
    }
}
