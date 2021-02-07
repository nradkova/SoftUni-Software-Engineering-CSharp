using BorderControl.Models;
using System;
using System.Collections.Generic;

namespace BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Inhabitant> inhabitants = new List<Inhabitant>();
            string input = string.Empty;
            while ((input=Console.ReadLine())!="End")
            {
                string[] info = input.Split();
                if (info.Length==2)
                {
                    Inhabitant robot = new Robot(info[0], info[1]);
                    inhabitants.Add(robot);
                }
                if (info.Length == 3)
                {
                    Inhabitant citizen = new Citizen(info[0], int.Parse(info[1]),info[2]);
                    inhabitants.Add(citizen);
                }
            }
            string condition =Console.ReadLine();
            foreach (var member in inhabitants)
            {
                if (member.Id.EndsWith(condition))
                {
                    Console.WriteLine(member);
                }
            }
        }
    }
}
