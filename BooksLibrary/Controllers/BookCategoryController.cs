using Data;
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
    public class BookCategoryController : ControllerBase
    {
        private readonly IBookCategoryService _bookCategoryService;
        public BookCategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }

        [HttpPost]
        [Route("AddBookCategory")]
        public async Task<IActionResult> AddBookCategory([FromBody] BookCategory model)
        {
            var result = await _bookCategoryService.AddBookCategory(model);
            return result.Status == true ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("GetAllBookCategories")]
        public async Task<ActionResult<IEnumerable<BookCategory>>> GetAllBookCategories()
        {
            var ListOfBookCategories = await _bookCategoryService.GetAllBookCategories();
            return ListOfBookCategories.Any() ? Ok(ListOfBookCategories) : NoContent();
        }

        [HttpGet]
        [Route("GetSingleBookCategory{productCategoryId}")]
        public async Task<ActionResult<BookCategory>> GetSingleBookCategory([FromRoute] int bookCategoryId)
        {
            var SingleBookCategory = await _bookCategoryService.GetSingleBookCategory(bookCategoryId);
            return SingleBookCategory != null ? Ok(SingleBookCategory) : NotFound();
        }



    }
}
