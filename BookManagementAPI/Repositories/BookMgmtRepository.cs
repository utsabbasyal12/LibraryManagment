using BookManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagementAPI.Repositories
{
    public class BookMgmtRepository : IBookMgmtRepository
    {
        private readonly ApplicationDbContext _context;

        public BookMgmtRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<BooksModel>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<BooksModel> GetBookById(int BookId)
        {
            return await _context.Books.FirstOrDefaultAsync(a => a.BookId == BookId);
        }
        public async Task<BooksModel> AddBooks(BooksModel model)
        {
            var result = await _context.Books.AddAsync(model);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<BooksModel> UpdateBooks(BooksModel model)
        {
            var result = await _context.Books.FirstOrDefaultAsync(a=>a.BookId == model.BookId);

            if(result != null)
            {
                result.Title = model.Title;
                result.Author = model.Author;
                result.Genre = model.Genre;
                result.AvailabilityStatus = model.AvailabilityStatus;

                await _context.SaveChangesAsync();
                
                return result;
            }
            return null;
        }
        public async Task DeleteBooks(int bookId)
        {
            var result = await _context.Books.FirstOrDefaultAsync(a=>a.BookId ==  bookId);
            if(result != null)
            {
                _context.Books.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        
    }
}
