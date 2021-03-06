using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Book : BaseClass
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

        public int BookCategoryId { get; set; }
        [JsonIgnore]
        public BookCategory BookCategory { get; set; }

    }
}
