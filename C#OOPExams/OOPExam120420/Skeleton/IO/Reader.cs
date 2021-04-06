using CounterStrike.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
