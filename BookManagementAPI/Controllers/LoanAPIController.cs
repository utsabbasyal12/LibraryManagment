using BookManagementAPI.Models;
using BookManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanAPIController : ControllerBase
    {
        private readonly ILoanService _service;

        public LoanAPIController(ILoanService service)
        {
            _service = service;
        }
        [HttpGet("GetAllLoans")]
        public async Task<IActionResult> GetLoans()
        {
            var loans = await _service.GetAllLoanAsync();
            return Ok(loans);
        }
        [HttpGet("GetLoanById")]
        public async Task<IActionResult> GetLoanById(int LoanId)
        {
            var loan = await _service.GetLoanByIdAsync(LoanId);
            return Ok(loan);
        }
        [HttpPost("AddLoan")]
        public async Task<IActionResult> AddLoan([FromBody] LoanModel model)
        {
            var Data = await _service.AddLoanAsync(model);
            return Ok(Data);
        }
        [HttpPost("UpdateLoan")]
        public async Task<IActionResult> UpdateLoad([FromBody] LoanModel model)
        {
            var Data = await _service.UpdateLoanAsync(model);
            return Ok(Data);
        }
        [HttpGet("DeleteLoan")]
        public async Task<IActionResult> DeleteLoan(int LoanId)
        {
            await _service.DeleteLoanAsync(LoanId);
            return Ok("Loan Deleted Successfully.");
        }
    }
}
