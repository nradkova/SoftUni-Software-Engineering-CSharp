using Raiding.Contracts;
using Raiding.Core;
using System;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
