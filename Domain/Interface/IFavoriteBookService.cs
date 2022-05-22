using Data.Model;
using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
  public  interface IFavoriteBookService
    {
        Task<GlobalResponse> AddBookToFavorite(BookToFavoriteRequest request);
        Task<GlobalResponse<IEnumerable<FavoriteBookResponse>>> GetFavoriteBooks();
    }
}
