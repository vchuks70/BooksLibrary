using Data;
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
        Task<GlobalResponse> AddBookCategory(BookCategory model);
    }
}
