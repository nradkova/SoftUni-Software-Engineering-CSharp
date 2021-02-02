using System;
using System.Collections.Generic;
using System.Linq;

namespace CompareObjects
{
  public class StartUp
    {
      static void Main(string[] args)
        {
            string input = string.Empty;
            List<Person> people = new List<Person>();
            while ((input=Console.ReadLine())!="END")
            {
                string[] tokens = input.Split();
                Person person = new Person(tokens[0]
                    , int.Parse(tokens[1]), tokens[2]);
                people.Add(person);
            }

            List<Person> uniquePeople = new List<Person>();
            int n =int.Parse(Console.ReadLine());

            for (int i = 0; i < people.Count; i++)
            {
                if (i!=n-1 && people[n-1].CompareTo(people[i])==0)
                {
                    uniquePeople.Add(people[i]);
                }
            }

            if (uniquePeople.Count!=0)
            {
                uniquePeople.Add(people[n-1]);
            }
            else
            {
                Console.WriteLine("No matches");
                return;
            }

            Console.WriteLine($"{uniquePeople.Count} " +
                $"{people.Count-uniquePeople.Count} {people.Count}");
        }
    }
}
