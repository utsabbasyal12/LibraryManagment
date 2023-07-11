using LibraryManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BooksModel> Books { get; set; }
    }
}
