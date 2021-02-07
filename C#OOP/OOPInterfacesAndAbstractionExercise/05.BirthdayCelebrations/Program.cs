using System;
using System.Collections.Generic;
using System.Linq;
using BirthdayCelebrations.Models;

namespace BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBorn> inhabitants = new List<IBorn>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split();
                if (info[0]=="Pet")
                {
                    IBorn pet = new Pet(info[1], info[2]);
                    inhabitants.Add(pet);
                }
                if (info[0] == "Citizen")
                {
                    IBorn citizen = new Citizen
                        (info[1], int.Parse(info[2]), info[3],info[4]);
                    inhabitants.Add(citizen);
                }
            }
            string condition = Console.ReadLine();
            var sortedMembers = inhabitants.Where(b => b.BirthDate.EndsWith(condition)).ToList();
            //if (sortedMembers.Count==0)
            //{
            //    Console.WriteLine("<empty output>");

            //}
            sortedMembers.ForEach(m => m.PrintBirthDate());
        }
    }
}
