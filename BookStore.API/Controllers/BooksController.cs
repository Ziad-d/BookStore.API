using BookStore.API.DTOs.BooksDTO;
using BookStore.API.Models;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]int id)
        {
            var book = await bookRepository.GetBookByIdAsync(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody]InputBookDTO bookDTO)
        {
            var result = await bookRepository.AddBookAsync(bookDTO);

            if (result == null)
                return NotFound("Cannot create one");

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDTO bookDTO, [FromRoute] int id)
        {
            var result = await bookRepository.UpdateBookAsync(bookDTO, id);

            if (result == null) 
                return NotFound("Can't Update");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await bookRepository.DeleteBookAsync(id);
            return Ok();
        }

    }
}
