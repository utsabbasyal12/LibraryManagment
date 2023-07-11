using LibraryManagment.Data;
using LibraryManagment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
    }
}
