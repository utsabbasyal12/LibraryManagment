using LibraryManagment.ViewModels;

namespace LibraryManagment.Managers
{
    public interface IBooksManager
    {
        Task<List<BookViewModel>> GetAllBooksAsync();
        Task<BookViewModel> GetBookByIdAsync(int Id);
        Task<BookViewModel> AddBookAsync(BookViewModel viewModel);
        Task<BookViewModel> UpdateBookAsync(BookViewModel viewModel);
        Task<string> DeleteBookAsync(int Id);
    }
}
