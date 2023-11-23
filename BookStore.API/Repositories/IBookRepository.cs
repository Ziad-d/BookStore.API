using BookStore.API.Models;

namespace BookStore.API.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();
    }
}
