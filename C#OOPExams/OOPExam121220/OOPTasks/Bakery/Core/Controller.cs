using System.Text;
using System.Linq;
using System.Collections.Generic;

using Bakery.Models.Drinks;
using Bakery.Models.Tables;
using Bakery.Core.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Models.BakedFoods;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Models.BakedFoods.Contracts;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private ICollection<IBakedFood> bakedFoods;
        private ICollection<IDrink> drinks;
        private ICollection<ITable> tables;
        private decimal totalIncome;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
            totalIncome = 0;
        }

        public string AddDrink(string type,
            string name, int portion, string brand)
        {
            IDrink drink 
                = CreateDrink(type, name, portion, brand);
            if (drink == null)
            {
                return null;
            }

            drinks.Add(drink);

            string msg = $"Added {name} " +
                $"({brand}) to the drink menu";
            return msg;
        }

        public string AddFood(string type,
            string name, decimal price)
        {
            IBakedFood bakedFood 
                = CreateFood(type, name, price);
            if (bakedFood == null)
            {
                return null;
            }

            bakedFoods.Add(bakedFood);

            string msg = $"Added {name} " +
                $"({type}) to the menu";
            return msg;
        }

        public string AddTable(string type,
            int tableNumber, int capacity)
        {
            ITable table 
                = CreateTable(type, tableNumber, capacity);
            if (table == null)
            {
                return null;
            }

            tables.Add(table);

            string msg = $"Added table number {tableNumber} " +
                $"in the bakery";
            return msg;
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = tables.Where(t => t.IsReserved == false);
            StringBuilder sb = new StringBuilder();
            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = GetTable(tableNumber);

            if (table == null)
            {
                return null;
            }

            decimal tableBill = table.GetBill();
            totalIncome += tableBill;
            table.Clear();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {tableBill:f2}");

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber,
            string drinkName, string drinkBrand)
        {
            ITable table = GetTable(tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            IDrink drink = GetDrink(drinkName, drinkBrand);
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = GetTable(tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            IBakedFood bakedFood = GetFood(foodName);
            if (bakedFood == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(bakedFood);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables
                .FirstOrDefault(t => t.IsReserved == false
                && t.Capacity >= numberOfPeople);
            if (table == null)
            {
                return $"No available table for " +
                    $"{numberOfPeople} people";
            }
            table.Reserve(numberOfPeople);

            return $"Table {table.TableNumber} has been reserved " +
                $"for {numberOfPeople} people";
        }

        private IDrink CreateDrink(string drinkType,
            string name, int portion, string brand)
        {
            IDrink drink = null;
            if (drinkType == DrinkType.Water.ToString())
            {
                drink = new Water(name, portion, brand);
            }
            if (drinkType == DrinkType.Tea.ToString())
            {
                drink = new Tea(name, portion, brand);
            }
           
            return drink;
        }

        private IBakedFood CreateFood(string foodType,
            string name, decimal price)
        {
            IBakedFood bakedFood = null;
            if (foodType == BakedFoodType.Bread.ToString())
            {
                bakedFood = new Bread(name,price);
            }
            if (foodType == BakedFoodType.Cake.ToString())
            {
                bakedFood = new Cake(name, price);
            }
           
            return bakedFood;
        }

        private ITable CreateTable(string tableType,
            int tableNumber, int capacity)
        {
            ITable table = null;
            if (tableType == TableType.InsideTable.ToString())
            {
                table = new InsideTable(tableNumber,capacity);
            }
            if (tableType == TableType.OutsideTable.ToString())
            {
                table = new OutsideTable(tableNumber, capacity);
            }
          
            return table;
        }

        private ITable GetTable(int tableNumber)
        {
            ITable table = tables
               .FirstOrDefault(t => t.TableNumber == tableNumber);
            return table;
        }
        private IDrink GetDrink(string name, string brand)
        {
            IDrink drink = drinks
               .FirstOrDefault
               (d => d.Name == name && d.Brand == brand);

            return drink;
        }
        private IBakedFood GetFood(string name)
        {
            IBakedFood bakedFood = bakedFoods
               .FirstOrDefault
               (f => f.Name == name);

            return bakedFood;
        }
    }
}
