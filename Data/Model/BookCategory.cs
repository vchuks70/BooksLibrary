using Data.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Data
{
    public class BookCategory : BaseClass
    {
        public string CategoryName { get; set; }
        [JsonIgnore]
        public List<Book>  Books { get; set; }

        //public BookCategory()
        //{
        //    Books = new List<Book>();
        //}
    }
}
