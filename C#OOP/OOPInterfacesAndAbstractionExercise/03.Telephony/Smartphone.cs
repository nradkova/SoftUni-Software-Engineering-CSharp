using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class Smartphone : IPhone, IWebBrowsable
    {
        public string BrowseWeb(string webSite)
        {
            string pattern = @"^(\D+)$";
            if (!Regex.Match(webSite, pattern).Success)
            {
                return "Invalid URL!";
            }
            return $"Browsing: {webSite}!";
        }

        public string MakeCalls(string number)
        {
            string pattern = @"^(\d+)$";
            if (!Regex.Match(number, pattern).Success)
            {
                return "Invalid number!";
            }
            return $"Calling... {number}";
        }
    }
}
