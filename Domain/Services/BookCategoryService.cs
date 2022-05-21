using Data;
using Data.Model;
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
            var ListOfBookCategory = await _context.CategoryName.ToListAsync();
            return ListOfBookCategory;
        }

        public async Task<BookCategory> GetSingleBookCategory(int BookCategoryId)
        {
            var SingleProduct = await _context.CategoryName.SingleOrDefaultAsync(x => x.Id == BookCategoryId);

            return SingleProduct;
        }

        public async Task<GlobalResponse> AddBookCategory(BookCategory model)
        {
            var Category = await _context.CategoryName.FirstOrDefaultAsync(x => x.CategoryName == model.CategoryName);
            if (Category != null)
                return new GlobalResponse { Status = false, Message = "Category Already Exist" };
            var NewCategoryName = new BookCategory
            {
                CategoryName = model.CategoryName
            };
            await _context.CategoryName.AddAsync(NewCategoryName);
            await _context.SaveChangesAsync();
            return new GlobalResponse { Status = true, Message = "New Category Created" };
        }
    }
}
