using LibraryManagment.Data;
using LibraryManagment.Models;
using LibraryManagment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            List<BookViewModel> list = new List<BookViewModel>();
            if (books != null)
            {
                foreach (var book in books)
                {
                    var BookViewModel = new BookViewModel()
                    {
                        BookId = book.BookId,
                        Title = book.Title,
                        Author = book.Author,
                        Genre = book.Genre,
                        AvailabilityStatus = book.AvailabilityStatus,
                    };
                    list.Add(BookViewModel);
                }
                return View(list);
            }
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookViewModel bookView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var book = new BooksModel()
                    {
                        Title = bookView.Title,
                        Author = bookView.Author,
                        Genre = bookView.Genre,
                        AvailabilityStatus = bookView.AvailabilityStatus,
                    };
                    _context.Books.Add(book);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Employee Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model data is not valid";
                    return View();
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
