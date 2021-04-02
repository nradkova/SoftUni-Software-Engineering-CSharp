using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int capacity;
        private readonly ICollection<IBakedFood> foodOrders;
        private readonly ICollection<IDrink> drinkOrders;


        protected Table(int tableNumber, int capacity,
            decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;

            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }
        public int TableNumber { get; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidTableCapacity);
                }
                capacity = value;
            }
        }

        public int NumberOfPeople { get; private set; }

        public decimal PricePerPerson { get; }

        public bool IsReserved { get; private set; }

        public decimal Price => PricePerPerson * NumberOfPeople;
               
        public IReadOnlyCollection<IBakedFood> FoodOrders
            => (IReadOnlyCollection<IBakedFood>)foodOrders;

        public IReadOnlyCollection<IDrink> DrinkdOrders
            => (IReadOnlyCollection<IDrink>)drinkOrders;

        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            IsReserved = false;
            NumberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return
                foodOrders.Sum(f => f.Price) +
                drinkOrders.Sum(d => d.Price) +
                Price;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson}");
            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {

            if (numberOfPeople <= 0)
            {
                throw new ArgumentException
                    (ExceptionMessages.InvalidNumberOfPeople);
            }
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }
    }
}
