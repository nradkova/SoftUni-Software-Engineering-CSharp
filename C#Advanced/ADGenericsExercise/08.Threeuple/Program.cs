using System;
using System.Security.Cryptography.X509Certificates;

namespace _08.Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstTokens = Console.ReadLine().Split();
            Threeuple<string, string, string> firstLine = new Threeuple<string, string, string>();
            firstLine.Item1 = $"{firstTokens[0]} {firstTokens[1]}";
            firstLine.Item2 = firstTokens[2];
            if (firstTokens.Length==4)
            {
            firstLine.Item3 = firstTokens[3];
            }
            else
            {
            firstLine.Item3 = $"{firstTokens[3]} {firstTokens[4]}";
            }

            string[] secondTokens = Console.ReadLine().Split();
            Threeuple<string, int, bool> secondLine = new Threeuple<string, int, bool>();
            secondLine.Item1 = secondTokens[0];
            secondLine.Item2 = int.Parse(secondTokens[1]);
            secondLine.Item3 = secondTokens[2] == "drunk" ? true : false;

            string[] thirdTokens = Console.ReadLine().Split();
            Threeuple<string, double, string> thirdLine = new Threeuple<string, double, string>();
            thirdLine.Item1 = thirdTokens[0];
            thirdLine.Item2 = double.Parse(thirdTokens[1]);
            thirdLine.Item3 = thirdTokens[2];

            Console.WriteLine(firstLine);
            Console.WriteLine(secondLine);
            Console.WriteLine(thirdLine);
        }
    }
}
