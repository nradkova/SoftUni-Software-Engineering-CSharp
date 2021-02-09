using System;

namespace Stealer
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            //var output =
            //    spy.StealFieldInfo("Stealer.Hacker",new string  []{ "username", "password" });
            //Console.WriteLine(output);

            //var output =
            //    spy.AnalyzeAcessModifiers("Stealer.Hacker");
            //Console.WriteLine(output);

            var output =
                spy.RevealPrivateMethods("Stealer.Hacker");
            Console.WriteLine(output);
        }
    }
}
