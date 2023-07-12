using BookManagementAPI.Models;

namespace BookManagementAPI.Repositories
{
    public interface IBookMgmtRepository
    {
        Task<List<BooksModel>> GetBooks();
        Task<BooksModel> GetBookById(int BookId);
        Task<BooksModel> AddBooks(BooksModel model);
        Task<BooksModel> UpdateBooks(BooksModel model);
        Task DeleteBooks(int bookId);
    }
}
