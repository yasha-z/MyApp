using Microsoft.AspNetCore.Mvc;

namespace Session1
{
    // TASK 2.3 — BooksController with one endpoint: GET /api/books
    [ApiController]//this tells that this is a controller and it will handle the requests and responses

    [Route("api/[controller]")]//[controller] is replaced by the controller name without "Controller"
    //api/books
    public class BooksController : ControllerBase 
    // controllerBase  provides methods for handling HTTP requests and responses
    //like ok(), notfound(), badrequest() etc
    {
        private readonly IBookService _bookService; //dependency injection: we are injecting the IBookService into the controller
//controller yeh service use karega to get the books
        public BooksController(IBookService bookService)
        //in program.cs we registered the IBookService with the BookService implementation
        {
            _bookService = bookService;
        }

        // GET /api/books — returns all books (test in Swagger)
        [HttpGet]//this is endpoint for GET request

        //actionresult says that this method will return either a List<Book> or an HTTP response
        public async Task<ActionResult<List<Book>>> GetAll()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }
    }
}
