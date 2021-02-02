using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> names = new Dictionary<string,int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                if (!names.ContainsKey(name))
                {
                    names.Add(name, i);
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, names.Keys));
        }
    }
}
