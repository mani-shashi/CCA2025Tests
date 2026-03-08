using Microsoft.EntityFrameworkCore;
using Library_Management_System.Models;

namespace Library_Management_System.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}