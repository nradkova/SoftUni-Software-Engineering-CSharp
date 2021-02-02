using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book:IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors;
        }
        public string Title { get; set; }
        public int Year { get; set; }
        public string[] Authors { get; set; }

        public int CompareTo( Book other)
        {
            int comparisonResult = Year .CompareTo(other.Year);
            if (comparisonResult == 0)
            {
                comparisonResult = Title.CompareTo(other.Title);
            }
            return comparisonResult;
        }

        public override string ToString()
        {
            return $"{Title} -> {Year}";
        }
    }
}
