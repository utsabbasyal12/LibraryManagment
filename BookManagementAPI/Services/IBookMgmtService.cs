using BookManagementAPI.Models;

namespace BookManagementAPI.Services
{
    public interface IBookMgmtService
    {
        Task<List<BooksModel>> GetAllBooks();
        Task<BooksModel> GetBookById(int BookId);
        Task<BooksModel> AddBookAsync(BooksModel model);
        Task<BooksModel> UpdateBooksAsync(BooksModel model);
        Task DeleteBookAsync(int BookId);
    }
}
