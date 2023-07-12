using BookManagementAPI.Models;
using BookManagementAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAPIController : ControllerBase
    {
        private readonly IBookMgmtService _service;

        public BookAPIController(IBookMgmtService service)
        {
            _service = service;
        }
        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _service.GetAllBooks();
            return Ok(books);
        }
        [HttpGet("GetBookById")]
        public async Task<IActionResult> GetBookById(int BookId)
        {
            var book = await _service.GetBookById(BookId);
            return Ok(book);
        }
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddNewBook([FromBody] BooksModel model)
        {
            var data = await _service.AddBookAsync(model);
            return Ok(data);
        }
        [HttpPost("UpdateBook")]
        public async Task<IActionResult> UpdateBooks([FromBody] BooksModel model)
        {
            var data = await _service.UpdateBooksAsync(model);
            return Ok(data);
        }
        [HttpGet("DeleteBook")]
        public async Task<IActionResult> DeleteBook(int Id)
        {
            await _service.DeleteBookAsync(Id);
            return Ok("Book deleted successfully.");
        }
    }
}
