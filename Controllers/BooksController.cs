using Microsoft.AspNetCore.Mvc;

namespace Session1
{
    // TASK 2.3 — BooksController with one endpoint: GET /api/books
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET /api/books — returns all books (test in Swagger)
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }
    }
}
