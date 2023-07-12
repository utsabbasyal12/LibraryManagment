using Microsoft.EntityFrameworkCore;

namespace BookManagementAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BooksModel> Books { get; set; }
    }
}
