using BookStore.API.DTOs.BooksDTO;
using BookStore.API.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null)
                return null;
            return book;
        }

        public async Task<Book> AddBookAsync(InputBookDTO book)
        {
            Book newBook = new Book()
            {
                Title = book.Title,
                Description = book.Description
            };

            context.Books.Add(newBook);
            await context.SaveChangesAsync();
            
            return newBook;
        }

        public async Task<Book> UpdateBookAsync(UpdateBookDTO book, int id)
        {
            var foundBook = await context.Books.FindAsync(id);
            if (foundBook == null)
                return null;

            foundBook.Title = (book.Title == null) ? foundBook.Title : book.Title;
            foundBook.Description = (book.Description == null) ? foundBook.Description : book.Description;

            context.Books.Update(foundBook);

            var result = await context.SaveChangesAsync();
            if (result == 0)
                return null;

            return foundBook;
        }

        public async Task DeleteBookAsync(int id)
        {
            var foundBook = new Book() { Id = id };

            context.Books.Remove(foundBook);
            
            await context.SaveChangesAsync();
        }
    }
}
