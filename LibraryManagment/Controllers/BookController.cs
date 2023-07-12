using LibraryManagment.Data;
using LibraryManagment.Managers;
using LibraryManagment.Models;
using LibraryManagment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBooksManager _manager;

        public BookController(ApplicationDbContext context, IBooksManager manager)
        {
            _context = context;
            _manager = manager;
        }
        public async Task GetAllBooks()
        {
            var Data = await _manager.GetAllBooksAsync();
            ViewBag.BookModel = Data;
        }
        [HttpGet]
        public async Task<IActionResult> Index(BookViewModel viewModel)
        {
            await GetAllBooks();
            return View(viewModel);
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookViewModel bookView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Message = await _manager.AddBookAsync(bookView);
                    if (Message != null)
                    {
                        TempData["successMessage"] = "Employee Created Successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        await GetAllBooks();
                        TempData["errorMessage"] ="Error on Adding";
                        return View("Index", bookView);

                    }
                }
                else
                {
                    return View("Index", bookView);
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
