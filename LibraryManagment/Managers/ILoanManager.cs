using LibraryManagment.ViewModels;

namespace LibraryManagment.Managers
{
    public interface ILoanManager
    {
        Task<List<LoanViewModel>> GetAllLoanAsync();
        Task<LoanViewModel> GetLoanByIdAsync(int Id);
        Task<LoanViewModel> AddLoanAsync(LoanViewModel viewModel);
        Task<LoanViewModel> UpdateLoanAsync(LoanViewModel viewModel);
        Task<string> DeleteLoanAsync(int Id);
    }
}
