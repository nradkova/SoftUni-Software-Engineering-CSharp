using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] symbols = Console.ReadLine().ToCharArray();
            Dictionary<char, int> symbolsAppearance = new Dictionary<char, int>();
            foreach (var item in symbols)
            {
                if (!symbolsAppearance.ContainsKey(item))
                {
                    symbolsAppearance.Add(item, 0);
                }
                symbolsAppearance[item]++;
            }
            foreach (var symbol in symbolsAppearance.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
