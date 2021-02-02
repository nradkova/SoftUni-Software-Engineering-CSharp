using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> contests = new HashSet<string>();
            string input = string.Empty;
            while ((input=Console.ReadLine())!= "end of contests")
            {
                string[] tokens = input.Split(':');
                string contestInfo = tokens[0] + tokens[1];
                contests.Add(contestInfo);
            }
            SortedDictionary<string, Dictionary<string,int>> students = new SortedDictionary<string, Dictionary<string, int>>();
            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = input.Split("=>");
                string contestInfo = tokens[0] + tokens[1];
                string studentName = tokens[2];
                int points = int.Parse(tokens[3]);
                if (contests.Contains(contestInfo))
                {
                    if (!students.ContainsKey(studentName))
                    {
                        students.Add(studentName, new Dictionary<string, int>());
                        students[studentName].Add( tokens[0],points);
                    }
                    else
                    {
                        if (!students[studentName].ContainsKey(tokens[0]))
                        {
                            students[studentName].Add(tokens[0], points);
                        }
                        else
                        {
                            if (students[studentName][tokens[0]] < points)
                            {
                                students[studentName][tokens[0]]=points;
                            }
                        }
                    }
                }
            }
            int maxResult = int.MinValue;
            string bestCandidate = string.Empty;
            foreach (var student in students)
            {
                if (student.Value.Values.Sum()>maxResult)
                {
                    maxResult = student.Value.Values.Sum();
                    bestCandidate = student.Key;
                }
            }
            Console.WriteLine($"Best candidate is {bestCandidate } with total {maxResult} points.");
            Console.WriteLine("Ranking: ");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key}");
                foreach (var contest in student.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }

        }
    }
}
