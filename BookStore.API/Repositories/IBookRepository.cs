﻿using BookStore.API.DTOs.BooksDTO;
using BookStore.API.Models;

namespace BookStore.API.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(InputBookDTO book);
        Task<Book> UpdateBookAsync(UpdateBookDTO book, int id);
        Task DeleteBookAsync(int id);
    }
}
