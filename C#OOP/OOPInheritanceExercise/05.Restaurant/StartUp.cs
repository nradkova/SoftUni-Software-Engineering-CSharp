namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Beverage ds = new Beverage("ccc",2.20m, 100);
            ds.Milliliters = 22;
            Coffee coffee = new Coffee("ddd", 1.2);
            System.Console.WriteLine(coffee.Price);
        }
    }
}