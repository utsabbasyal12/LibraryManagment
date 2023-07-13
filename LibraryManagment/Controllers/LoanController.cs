using LibraryManagment.Managers;
using LibraryManagment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagment.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILoanManager _manager;
        private readonly IMemberManager _memberManager;
        private readonly IBooksManager _booksManager;

        public LoanController(ILoanManager manager,IMemberManager memberManager, IBooksManager booksManager) 
        {
            _manager = manager;
            _memberManager = memberManager;
            _booksManager = booksManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetLoanById(int Id)
        {
            var Data = await _manager.GetLoanByIdAsync(Id);
            return Json(Data);
        }
        public async Task GetAllLoans()
        {
            var loans = await _manager.GetAllLoanAsync();
            // Fetch member names
            var memberIds = loans.Select(loan => loan.MemberId).Distinct().ToList();
            var members = await _memberManager.GetAllMembersAsync();
            var memberDictionary = members.ToDictionary(member => member.MemberId, member => member.Name);

            // Fetch book names
            var bookIds = loans.Select(loan => loan.BookId).Distinct().ToList();
            var books = await _booksManager.GetAllBooksAsync();
            var bookDictionary = books.ToDictionary(book => book.BookId, book => book.Title);

            var loanData = loans.Select(loan => new
            {
                Loan = loan,
                MemberName = memberDictionary.TryGetValue(loan.MemberId, out var memberName) ? memberName : "Unknown",
                BookName = bookDictionary.TryGetValue(loan.BookId, out var bookName) ? bookName : "Unknown"
            });
            ViewBag.MemberName = memberDictionary.Select(member => new SelectListItem
            {
                Value = member.Key.ToString(),
                Text = member.Value
            }).ToList();

            ViewBag.BookName = bookDictionary.Select(member => new SelectListItem
            {
                Value = member.Key.ToString(),
                Text = member.Value
            }).ToList();

            ViewBag.Loans = loanData;
        }
        [HttpGet]
        public async Task<IActionResult> Index(LoanViewModel viewModel)
        {
            await GetAllLoans();
            return View(viewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Create(LoanViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.LoanId != 0)
                {
                    var data = await _manager.UpdateLoanAsync(viewModel);
                    if (data != null)
                    {
                        TempData["successMessage"] = "Loan Updated Successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        await GetAllLoans();
                        TempData["errorMessage"] = "Error on Updating";
                        return View("Index", viewModel);

                    }
                }
                else
                {
                    viewModel.ReturnDate = null;
                    var data = await _manager.AddLoanAsync(viewModel);
                    if (data != null)
                    {
                        TempData["successMessage"] = "Loan Created Successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        await GetAllLoans();
                        TempData["errorMessage"] = "Error on Adding";
                        return View("Index", viewModel);

                    }
                }

            }
            else
            {
                await GetAllLoans();
                return View("Index", viewModel);
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var data = await _manager.DeleteLoanAsync(Id);
            TempData["successMessage"] = data;
            await GetAllLoans();
            return View("Index");
        }
    }
}
