using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Person person = new Person(input[0], int.Parse(input[1]));
                people.Add(person);
            }
            people = people.Where(person => person.Age > 30)
                .OrderBy(person => person.Name).ToList();
            foreach (var person in people)
            {
            Console.WriteLine($"{person.Name} - " +
                $"{person.Age}");
            }
        }
    }
}
