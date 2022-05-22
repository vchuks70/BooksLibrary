using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Domain.Helper;
using Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteBookController : ControllerBase
    {
        private readonly IFavoriteBookService _favoriteBookService;

        public FavoriteBookController(IFavoriteBookService favoriteBookService)
        {
            _favoriteBookService = favoriteBookService;
        }

        [HttpGet]
        public async Task<ActionResult<GlobalResponse<IEnumerable<FavoriteBookResponse>>>> GetFavoriteBooks()
        {
            var response = await _favoriteBookService.GetFavoriteBooks();
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpPost("add-book-to-favorite")]
        public async Task<ActionResult<GlobalResponse>> AddBookToFavorite([FromBody] BookToFavoriteRequest request)
        {
            var response = await _favoriteBookService.AddBookToFavorite(request);
            return response.Status ? Ok(response) : BadRequest(response);
        }
    }
}
