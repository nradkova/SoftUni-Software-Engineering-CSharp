using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = File.ReadAllLines("../../../words.txt");
            Dictionary<string, int> wordOccurance = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                string[] text = File.ReadAllText("../../../text.txt").Split(new char[] { '-', ' ', '.', ',', '?', '!' });
                int count = text.Where(x => x.ToLower() == words[i]).ToArray().Length;
                wordOccurance.Add(words[i], count);
            }
            foreach (var word in wordOccurance.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}
