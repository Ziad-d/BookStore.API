using BookStore.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await bookRepository.GetAllBooksAsync();

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
