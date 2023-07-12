using BookManagementAPI.Models;
using BookManagementAPI.Repositories;

namespace BookManagementAPI.Services
{
    public class BookMgmtService : IBookMgmtService
    {
        private readonly IBookMgmtRepository _repository;

        public BookMgmtService(IBookMgmtRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BooksModel>> GetAllBooks()
        {
            return await _repository.GetBooks();
        }
        public async Task<BooksModel> GetBookById(int BookId)
        {
            return await _repository.GetBookById(BookId);
        }
        public async Task<BooksModel> AddBookAsync(BooksModel model)
        {
            return await _repository.AddBooks(model);
        }
        public async Task<BooksModel> UpdateBooksAsync(BooksModel model)
        {
            return await _repository.UpdateBooks(model);
        }
        public async Task DeleteBookAsync(int BookId)
        {
            await _repository.DeleteBooks(BookId);
        }
    }
}
