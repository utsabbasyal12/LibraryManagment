using Microsoft.EntityFrameworkCore;

namespace BookManagementAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BooksModel> Books { get; set; }
        public DbSet<LibraryMembersModel> Members { get; set; }
        public DbSet<LoanModel> Loans { get; set; }

    }
}
