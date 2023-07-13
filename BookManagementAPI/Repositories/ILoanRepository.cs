using BookManagementAPI.Models;

namespace BookManagementAPI.Repositories
{
    public interface ILoanRepository
    {
        Task<List<LoanModel>> GetAllLoan();
        Task<LoanModel> GetLoanByID(int Id);
        Task<LoanModel> AddLoan(LoanModel model);
        Task<LoanModel> UpdateLoan(LoanModel model);
        Task DeleteLoan(int Id);
    }
}
