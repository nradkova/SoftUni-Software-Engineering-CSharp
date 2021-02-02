using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> rezervation = new Dictionary<string, HashSet<string>>()
            {
                { "VIP",new HashSet<string>() },
                { "Regular",new HashSet<string>() }
            };
            string input = string.Empty;
            while ((input=Console.ReadLine())!="PARTY")
            {
                if (input.Length==8)
                {
                    if (char.IsDigit(input[0]))
                    {
                        rezervation["VIP"].Add(input);
                    }
                    else
                    {
                        rezervation["Regular"].Add(input);
                    }
                }
            }
            while ((input = Console.ReadLine()) != "END")
            {
                if (char.IsDigit(input[0]))
                {
                    if (rezervation["VIP"].Contains(input))
                    {
                        rezervation["VIP"].Remove(input);
                    } 
                }
                else
                {
                    if (rezervation["Regular"].Contains(input))
                    {
                        rezervation["Regular"].Remove(input);
                    }
                }
            }
            Console.WriteLine(rezervation.Sum(x=>x.Value.Count));
            foreach (var group in rezervation)
            {
                if (group.Value.Count>0)
                {
                Console.WriteLine(string.Join(Environment.NewLine,group.Value));
                }
            }
        }
    }
}
