using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string []personInfo = Console.ReadLine().Split(";");
            List<Person> people = new List<Person>();
            for (int i = 0; i < personInfo.Length; i++)
            {
                string[] tokens = personInfo[i].Split("=");
                Person person = null;
                try
                {
                    person = new Person(tokens[0], decimal.Parse(tokens[1]));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                if (person!=null)
                {
                    people.Add(person);
                }
            }
            string[] productInfo = Console.ReadLine().Split(";"
                ,StringSplitOptions.RemoveEmptyEntries);
            List<Product> products = new List<Product>();
            for (int i = 0; i < productInfo.Length; i++)
            {
                string[] tokens = productInfo[i].Split("=");
                Product product = null;
                try
                {
                    product = new Product(tokens[0], decimal.Parse(tokens[1]));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                if (product != null)
                {
                    products.Add(product);
                }
            }
            string command = string.Empty;
            while ((command=Console.ReadLine())!="END")
            {
                string[] tokens = command.Split();
                Person person = null;
                     Product product = null;
                if (people.Any(X=>X.Name==tokens[0]))
                {
                    person = people
                        .FirstOrDefault(p => p.Name == tokens[0]);
                }
                if (products.Any(X => X.Name == tokens[1]))
                {
                     product = products
                        .FirstOrDefault(p => p.Name == tokens[1]);
                }
                if (person!=null&&product!=null)
                {
                    person.Buy(product);
                }
            }
            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
