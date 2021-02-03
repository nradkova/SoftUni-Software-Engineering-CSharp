using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string input = reader.ReadLine();
                int count = 0;
                while (input != null)
                {
                    if (count % 2 == 0)
                    {
                        Regex pattern = new Regex("[-,.!?]");
                        var result = pattern.Replace(input, "@")
                             .Split().ToArray().Reverse();
                        Console.WriteLine(string.Join(" ", result));
                    }
                    count++;
                    input = reader.ReadLine();
                }
            }
        }
    }
}
