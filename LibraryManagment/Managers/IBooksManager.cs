using LibraryManagment.ViewModels;

namespace LibraryManagment.Managers
{
    public interface IBooksManager
    {
        Task<List<BookViewModel>> GetAllBooksAsync();
    }
}
