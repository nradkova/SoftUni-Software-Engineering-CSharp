using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Citizen> citizens = new List<Citizen>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                citizens.Add(new Citizen
                    (tokens[0], tokens[1], int.Parse(tokens[2])));
            }
            foreach (var citizen in citizens)
            {
                citizen.GetName();
                //((IPerson)citizen).GetName();
                //((IResident)citizen).GetName();
            }
        }
    }
}
