using BookManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagementAPI.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<LoanModel>> GetAllLoan()
        {
            return await _context.Loans.ToListAsync();
        }
        public async Task<LoanModel> GetLoanByID(int Id)
        {
            return await _context.Loans.FirstOrDefaultAsync(x=>x.LoanId == Id);
        }
        public async Task<LoanModel> AddLoan(LoanModel model)
        {
            var result = await _context.Loans.AddAsync(model);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<LoanModel> UpdateLoan(LoanModel model)
        {
            var result = await _context.Loans.FirstOrDefaultAsync(x => x.LoanId == model.LoanId);

            if(result != null)
            {
                result.MemberId = model.MemberId;
                result.BookId = model.BookId;
                result.IssueDate = model.IssueDate;
                result.ReturnDate = model.ReturnDate;

                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async Task DeleteLoan(int Id)
        {
            var result = await _context.Loans.FirstOrDefaultAsync(x => x.LoanId == Id);
            if(result != null)
            {
                _context.Loans.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}
