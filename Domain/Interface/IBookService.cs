using Data.Model;
using Domain.DTO.Requests;
using Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> Get();  
        Task<Book> Get(int id);
        Task<GlobalResponse<Book>> Create(CreateBookRequest request);
        Task<GlobalResponse> Update(int bookId, UpdateBookRequest request);
        Task<GlobalResponse> Delete(int id);

    }
}
