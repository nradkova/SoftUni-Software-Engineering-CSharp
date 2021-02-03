using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            string input = string.Empty;
            List<string> filters = new List<string>();

            while ((input = Console.ReadLine()) != "Print")
            {
                input = DefineFilters(input, filters);
            }

            while (filters.Count != 0)
            {
                string currentFilter = filters.First();
                filters.RemoveAt(0);
                string[] tokens = currentFilter.Split(";");
                string criteria = tokens[0];
                string value = tokens[1];

                names = PerformFilter(names, criteria, value);
            }
            Action<List<string>> print = Print(names);
            print(names);

        }

        static string DefineFilters(string input, List<string> filters)
        {
            if (input.StartsWith("Add"))
            {
                input = input.Remove(0, 11);
                filters.Add(input);
            }
            else
            {
                input = input.Remove(0, 14);
                filters.Remove(input);
            }

            return input;
        }

        static Action<List<string>> Print(List<string> names)
        {
            return x =>
            {
                Console.WriteLine(string.Join(" ", names));
            };
        }

        static List<string> PerformFilter(List<string> names, string criteria, string value)
        {
            Func<string, bool> condition;
            List<string> temp = new List<string>();
            foreach (var name in names)
            {
                condition = DefineCondition(criteria, value, name);
                if (!condition(name))
                {
                    temp.Add(name);
                }
            }

            return names = temp;
        }

        static Func<string, bool> DefineCondition(string criteria, string value, string name)
        {
            Func<string, bool> condition;
            switch (criteria)
            {
                case "Starts with":
                    return condition = name => name.StartsWith(value);
                case "Ends with":
                    return condition = name => name.EndsWith(value);
                case "Length":
                    return condition = name => name.Length == int.Parse(value);
                case "Contains":
                    return condition = name => name.Contains(value);
                default:
                    return null;
            }
        }
    }
}
