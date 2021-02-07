using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class StationaryPhone : IPhone
    {
        public string MakeCalls(string number)
        {
            string pattern = @"^(\d+)$";
            if (!Regex.Match(number, pattern).Success)
            {
                return "Invalid number!";
            }
            return $"Dialing... {number}";
        }
    }
}
