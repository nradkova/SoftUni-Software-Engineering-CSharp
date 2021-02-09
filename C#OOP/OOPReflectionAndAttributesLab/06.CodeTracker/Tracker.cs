using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public Tracker()
        {

        }

        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            var methods = type.GetMethods
                (BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            foreach (var method in methods)
            {
                if (method.CustomAttributes
                     .Any(a => a.AttributeType == typeof(AuthorAttribute)))
                {

                    var customAttrs = method.GetCustomAttributes(false);

                    foreach (AuthorAttribute attr in customAttrs)
                    {
                        Console.WriteLine($"{method.Name} is written by {attr.Name}");
                    }
                }
            }
        }
    }
}