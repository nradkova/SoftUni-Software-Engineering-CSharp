using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                string criteria = tokens[1];
                string value = tokens[2];

               names= PerformFilter(names, command, criteria, value);
            }
            Action<List<string>> print = Print(names);
            print(names);

        }
        static Action<List<string>> Print(List<string> names)
        {
            return x =>
            {
                if (names.Count == 0)
                {
                    Console.WriteLine("Nobody is going to the party!");
                }
                else
                {
                    Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
                }
            };
        }
        static List<string> PerformFilter(List<string> names, string command, string criteria, string value)
        {
            Func<string, bool> condition;
            List<string> temp = new List<string>();

            foreach (var name in names)
            {
                condition = DefineCondition(criteria, value, name);
                if (command == "Remove")
                {
                    if (!condition(name))
                    {
                        temp.Add(name);
                    }
                }
                else if (command == "Double")
                {
                    if (condition(name))
                    {
                        temp.Add(name);
                    }
                    temp.Add(name);
                }
            }
            return temp;
        }
    
        static Func<string, bool> DefineCondition(string command, string value, string name)
        {
            Func<string, bool> condition;
            switch (command)
            {
                case "StartsWith":
                    return condition = name => name.StartsWith(value);
                case "EndsWith":
                    return condition = name => name.EndsWith(value);
                case "Length":
                    return condition = name => name.Length == int.Parse(value);
                default:
                    return null;
            }
        }
    }
}
