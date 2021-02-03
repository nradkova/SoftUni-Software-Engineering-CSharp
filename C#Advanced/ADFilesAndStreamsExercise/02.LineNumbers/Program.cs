using System;
using System.IO;
using System.Text.RegularExpressions;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var textLines = File.ReadAllLines("../../../text.txt");
            for (int i = 0; i < textLines.Length; i++)
            {
                string line = textLines[i];
                int lettersCount = CountLetters(line);
                int marksCount = CountMarks(line);

                Console.WriteLine($"Line {i + 1}: {line}({lettersCount})({marksCount})");
            }
        }
        static int CountLetters(string input)
        {
            Regex pattern = new Regex("[a-zA-Z]");
            int count = pattern.Matches(input).Count;
            return count;
        }
        static int CountMarks(string input)
        {
            Regex pattern = new Regex("[^a-zA-Z 0-9]");
            int count = pattern.Matches(input).Count;
            return count;
        }
    }
}
