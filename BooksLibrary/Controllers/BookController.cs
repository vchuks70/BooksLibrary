using Data.Model;
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
        public async Task<ActionResult<Book>> PostBooks([FromBody] Book book)
        {
            var newBook = await _bookService.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook.Id }, newBook);
        }

        public async Task <ActionResult> PutBooks(int id, [FromBody] Book book)
        {
            if(id != book.Id)
            {
                return BadRequest();
            }
            await _bookService.Update(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var bookToDelete = await _bookService.Get(id);
            if (bookToDelete == null)
                return NotFound();
            await _bookService.Delete(bookToDelete.Id);
            return NoContent();
        }
    }
}
