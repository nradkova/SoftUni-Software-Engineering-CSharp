using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,List< decimal>> students = new Dictionary<string,List< decimal>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                if (!students.ContainsKey(input[0]))
                {
                    students.Add(input[0], new List<decimal>());
                }
                decimal grade = decimal.Parse(input[1]);
                students[input[0]].Add(grade);
            }
            foreach (var student in students)
            {
                Console.Write($"{student.Key} ->");
                    foreach (var grade in student.Value)
                {
                    Console.Write($" {grade:f2}");
                }
                  Console.Write($" (avg: {student.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
