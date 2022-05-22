using Data;
using Domain.DTO.Requests;
using Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{   
    public interface IBookCategoryService
    {
        Task<IEnumerable<BookCategory>> GetAllBookCategories();
        Task<BookCategory> GetSingleBookCategory(int BookCategoryId);
        Task<GlobalResponse> AddBookCategory(AddBookCategoryRequest model);
        Task<GlobalResponse> MoveBookToCategory(MoveBookToCategoryRequest model);
        Task<GlobalResponse> UpdateBookCategory(UpdateBookCategoryRequest model);
        Task<GlobalResponse> DeleteCategory(int BookCategoryId);
    }
}
