using Data.Model;
using Domain.DTO.Requests;
using Domain.Helper;
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
        public async Task<GlobalResponse<Book>> Create(CreateBookRequest request)
        {
            var Category = await _context.BookCategories.FirstOrDefaultAsync(x => x.Id == request.BookCategoryId);
            if (Category is  null)
                return new GlobalResponse<Book> { Status = false, Message = "Category Does Not Exist" };

            var book = new Book
            {
                Author = request.Author,
                Title = request.Title,
                Description = request.Description,
                BookCategory = Category,
                BookCategoryId = Category.Id
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return new GlobalResponse<Book>
            {
                Data = book,
                Message = "successful",
                Status = true
            };
        }

        public async Task<GlobalResponse> Delete(int id)
        {
            var BookToDelete = await _context.Books.FindAsync(id);
            if (BookToDelete is null)
                return new GlobalResponse { Status = false, Message = "Book does not exist" };


            _context.Books.Remove(BookToDelete);
            await _context.SaveChangesAsync();


            return new GlobalResponse
            {
                Message = "successful",
                Status = true
            };
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

        public async Task<GlobalResponse> Update(int bookId, UpdateBookRequest request)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book is null)
                return new GlobalResponse { Status = false, Message = "Book does not exist" };

            book.Author = request.Author;
            book.Description = request.Description;
            book.Title = request.Title;

//            _context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return new GlobalResponse
            {
                Message = "successful",
                Status = true
            };
        }

            
    }
}
