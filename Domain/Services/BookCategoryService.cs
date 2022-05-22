using Data;
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
    public class BookCategoryService : IBookCategoryService
    {
        private readonly BookContext _context;
        public BookCategoryService(BookContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookCategory>> GetAllBookCategories()
        {
            var ListOfBookCategory = await _context.BookCategories.ToListAsync();
            return ListOfBookCategory;
        }

        public async Task<BookCategory> GetSingleBookCategory(int BookCategoryId)
        {
            var bookCategory = await _context.BookCategories.SingleOrDefaultAsync(x => x.Id == BookCategoryId);

            return bookCategory;
        }

        public async Task<GlobalResponse> AddBookCategory(AddBookCategoryRequest model)
        {
            var Category = await _context.BookCategories.FirstOrDefaultAsync(x => x.CategoryName == model.CategoryName);
            if (Category != null)
                return new GlobalResponse { Status = false, Message = "Category Already Exist" };
            var NewCategoryName = new BookCategory
            {
                CategoryName = model.CategoryName
            };
            await _context.BookCategories.AddAsync(NewCategoryName);
            await _context.SaveChangesAsync();
            return new GlobalResponse { Status = true, Message = "New Category Created" };
        }

        public async Task<GlobalResponse> MoveBookToCategory(MoveBookToCategoryRequest model)
        {
            var currentCategory = await _context.BookCategories.Include(x => x.Books).FirstOrDefaultAsync(x => x.Id == model.CurrentBookCateogryId);
            if (currentCategory is null)
                return new GlobalResponse { Status = false, Message = "Current category does not exist" };

            var newCategory = await _context.BookCategories.FirstOrDefaultAsync(x => x.Id == model.NewBookCategoryId);
            if (currentCategory is null)
                return new GlobalResponse { Status = false, Message = "new category does not exist" };
            foreach (var item in currentCategory.Books)
            {
                item.BookCategoryId = newCategory.Id;
            }
            await _context.SaveChangesAsync();

            return new GlobalResponse
            {
                Message = "successful",
                Status = true
            };

        }

        public async Task<GlobalResponse> DeleteCategory(int BookCategoryId)
        {
            var category = await _context.BookCategories.Include(x => x.Books).FirstOrDefaultAsync(x => x.Id == BookCategoryId);
            if (category is null)
                return new GlobalResponse { Status = false, Message = "category does not exist" };
            if (category.Books.Any())
                return new GlobalResponse { Status = false, Message = "Category contains books, kindly move them to another category before deleting" };

            _context.BookCategories.Remove(category);
            await _context.SaveChangesAsync();
            return new GlobalResponse
            {
                Message = "successful",
                Status = true
            };


        }

        public async Task<GlobalResponse> UpdateBookCategory(UpdateBookCategoryRequest model)
        {
            var book = await _context.Books.FindAsync(model.BookId);
            if (book is null)
                return new GlobalResponse { Status = false, Message = "Book does not exist" };

            var category = await _context.BookCategories.FirstOrDefaultAsync(x => x.Id == model.NewCategoryId);
            if (category is null)
                return new GlobalResponse { Status = false, Message = "category does not exist" };

            book.BookCategoryId = category.Id;
        
             await _context.SaveChangesAsync();

            return new GlobalResponse
            {
                Message = "successful",
                Status = true
            };

}
    }
}
