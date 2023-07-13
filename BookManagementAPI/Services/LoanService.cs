using BookManagementAPI.Models;
using BookManagementAPI.Repositories;

namespace BookManagementAPI.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _repository;

        public LoanService(ILoanRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LoanModel>> GetAllLoanAsync()
        {
            return await _repository.GetAllLoan();
        }
        public async Task<LoanModel> GetLoanByIdAsync(int Id)
        {
            return await _repository.GetLoanByID(Id);
        }
        public async Task<LoanModel> AddLoanAsync(LoanModel model)
        {
            return await _repository.AddLoan(model);    
        }
        public async Task<LoanModel> UpdateLoanAsync(LoanModel model)
        {
            return await _repository.UpdateLoan(model);
        }
        public async Task DeleteLoanAsync(int Id)
        {
            await _repository.DeleteLoan(Id);
        }
    }
}
