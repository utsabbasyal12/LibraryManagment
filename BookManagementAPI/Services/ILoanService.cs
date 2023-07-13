using BookManagementAPI.Models;

namespace BookManagementAPI.Services
{
    public interface ILoanService
    {
        Task<List<LoanModel>> GetAllLoanAsync();
        Task<LoanModel> GetLoanByIdAsync(int Id);
        Task<LoanModel> AddLoanAsync(LoanModel model);
        Task<LoanModel> UpdateLoanAsync(LoanModel model);
        Task DeleteLoanAsync(int Id);
    }
}
