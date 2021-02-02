using System;
using System.Linq;

namespace _07.Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                string[] info = Console.ReadLine().Split();
                if (info.Length == 3)
                {
                    string name = $"{info[0]} {info[1]}";
                    string address = info[2];
                    var personalInfo = new Tuple<string, string>
                        (name, address);
                    personalInfo.PrintItems();
                }
                else
                {
                    int litres;
                    if (Int32.TryParse(info[1], out litres))
                    {
                        string name = info[0];
                        var personalInfo = new Tuple<string, int>
                            (name, litres);
                        personalInfo.PrintItems();
                    }
                    else
                    {
                        int var1 = int.Parse(info[0]); ;
                        double var2 = double.Parse(info[1]); ;
                        var personalInfo = new Tuple<int, double>
                            (var1, var2);
                        personalInfo.PrintItems();
                    }
                }
            }
        }
    }
}
