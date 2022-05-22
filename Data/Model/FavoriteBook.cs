using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class FavoriteBook : BaseClass
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string BookTitle { get; set; }   
        public int CategoryId { get; set; }
        public BookCategory BookCateegory { get; set; }
        public string BookCateegoryName { get; set; }
    }
}
    