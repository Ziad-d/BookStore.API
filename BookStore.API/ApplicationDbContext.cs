using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
    }
}
