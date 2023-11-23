using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;

        public BookRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await context.Books.ToListAsync();
        }
    }
}
