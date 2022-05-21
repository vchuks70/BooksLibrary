using Data.Model;
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
        Task<Book> Create(Book book);
        Task Update(Book book);
        Task Delete(int id);

    }
}
