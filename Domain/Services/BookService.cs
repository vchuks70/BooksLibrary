using Data.Model;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class BookService : IBookService
    {
        private readonly BookContext _context;
        public BookService(BookContext context)
        {
            _context = context;  
        }
        public async Task<Book> Create(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task Delete(int id)
        {
            var BookToDelete = await _context.Books.FindAsync(id);
            _context.Books.Remove(BookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> Get()
        {
            var BookList = await _context.Books.ToListAsync();
            return BookList;
        }

        public async Task<Book> Get(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task Update(Book book)
        {
            _context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        
    }
}
