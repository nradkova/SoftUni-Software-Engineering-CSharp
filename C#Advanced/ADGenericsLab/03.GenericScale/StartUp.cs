using System;

namespace GenericScale
{
    class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> scale = new EqualityScale<int>(5, 30);
            Console.WriteLine(scale.AreEqual());
        }
    }
}
