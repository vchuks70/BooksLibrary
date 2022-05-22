using Data.Model;
using Domain.DTO.Requests;
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
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            return await _bookService.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBooks([FromBody] CreateBookRequest book)
        {
            var response = await _bookService.Create(book);
            return response.Status ? Ok(response) : BadRequest(response);
            
        }

        [HttpPut("{id}")]
        public async Task <ActionResult> PutBooks(int id, [FromBody] UpdateBookRequest request)
        {
            var response = await _bookService.Update(id, request);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var response = await _bookService.Delete(id);
            return response.Status ? Ok(response) : BadRequest(response);
        }
    }
}
