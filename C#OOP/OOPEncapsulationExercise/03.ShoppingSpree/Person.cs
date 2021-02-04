using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree
{
   public class Person
    {
        private string  name;
        private decimal money;
        private List<Product> bag;
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            Bag = new List<Product>();
        }
        public List<Product> Bag
        {
            get { return bag; }
            set { bag = value; }
        }

        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public string  Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public void Buy(Product product)
        {
            if (product.Cost<=Money)
            {
                Money -= product.Cost;
                Bag.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }
        public override string ToString()
        {
            List<string> currentBag = new List<string>();
            foreach (var item in Bag)
            {
                currentBag.Add(item.Name);
            }
            if (currentBag.Count==0)
            {
                return $"{Name} - Nothing bought";
            }
            else
            {
            return $"{Name} - {string.Join(", ",currentBag) }";
            }
        }
    }
}
