using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
  public  class DateModifier
    {
        private int difference;
        

        public DateModifier(string startDate,string endDate)
        {
            Difference = CalculateDifference(startDate, endDate);
        }

        public int  Difference { get; set; }

       public static int CalculateDifference(string startDate,string endDate)
        {
            int[] startDateTokens = startDate.Split()
                .Select(int.Parse).ToArray();
            int[] endDateTokens = endDate.Split()
                .Select(int.Parse).ToArray();
            DateTime firstDate = new DateTime
                (startDateTokens[0], startDateTokens[1], startDateTokens[2]);
            DateTime lastDate = new DateTime
               (endDateTokens[0], endDateTokens[1], endDateTokens[2]);
            TimeSpan duration = lastDate - firstDate;
            return Math.Abs( duration.Days);
        }
    }
}
