using Data.Model;
using Domain.DTO.Requests;
using Domain.DTO.Responses;
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
    public class FavoriteBookService : IFavoriteBookService
    {
        public BookContext _context;

        public FavoriteBookService(BookContext context)
        {
            _context = context;
        }

        public async Task<GlobalResponse> AddBookToFavorite(BookToFavoriteRequest request)
        {
            // find book

            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == request.BookId);
            if (book is null)
            {
                return new GlobalResponse
                {
                    Message = "Invalid book",
                    Status = false
                };
            }
            var category = await _context.BookCategories.FirstOrDefaultAsync(x => x.Id == book.BookCategoryId);

            if (book is null)
            {
                return new GlobalResponse
                {
                    Message = "Internal category error",
                    Status = false
                };
            }

            var favorite = new FavoriteBook
            {
                Book = book,
                BookId = book.Id,
                BookCateegory = category,
                CategoryId = category.Id,
                BookCateegoryName = category.CategoryName,
                BookTitle = book.Title
            };

            await _context.AddAsync(favorite);
            await _context.SaveChangesAsync();
            return new GlobalResponse
            {
                Message = "succesful",
                Status = true
            };

        }

        public async Task<GlobalResponse<IEnumerable<FavoriteBookResponse>>> GetFavoriteBooks()
        {
            var favoriteBooks = await _context.FavoriteBooks.Select(x  => new FavoriteBookResponse { 
                BookTitle = x.BookTitle,
                CategoryName = x.BookCateegoryName
            }).ToListAsync();

            return new GlobalResponse<IEnumerable<FavoriteBookResponse>> {

                Message = "succesful",
                Status = true,
                Data = favoriteBooks
            };
        }
    }
}
