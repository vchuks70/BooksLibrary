using Data.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Data
{
    public class BookCategory : BaseClass
    {
        public string CategoryName { get; set; }
        public IEnumerable<Book>  Books { get; set; }

        public BookCategory()
        {
            Books = new Collection<Book> ();
        }
    }
}
