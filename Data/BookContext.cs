using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> CategoryName { get; set; }
        public DbSet<PersonClass> FavoriteBook { get; set; }
    }
}
