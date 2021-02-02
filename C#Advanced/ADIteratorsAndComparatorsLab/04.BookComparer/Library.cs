using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public IEnumerator<Book> GetEnumerator()
        {
           books.Sort(new BookComparator());
            return new LibraryIterator(books);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public class LibraryIterator : IEnumerator<Book>
        {

            private int index = -1;

            public LibraryIterator(List<Book> books)
            {
                Books = books;
            }
            public List<Book> Books { get; set; }
            public Book Current => Books[index];

            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext() => ++index < Books.Count;

            public void Reset()
            {
                index = -1;
            }
        }
       
    }
}
