using LibraryManagment.Data;
using LibraryManagment.Managers;
using LibraryManagment.Models;
using LibraryManagment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Controllers
{
    public class BookController : Controller
    {
        private readonly IBooksManager _manager;

        public BookController(IBooksManager manager)
        {
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
                    if (bookView.BookId != 0)
                    {
                        var data = await _manager.UpdateBookAsync(bookView);
                        if (data != null)
                        {
                            TempData["successMessage"] = "Book Updated Successfully";
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            await GetAllBooks();
                            TempData["errorMessage"] = "Error on Updating";
                            return View("Index", bookView);

                        }
                    }
                    else
                    {
                        var data = await _manager.AddBookAsync(bookView);
                        if (data != null)
                        {
                            TempData["successMessage"] = "Book Created Successfully";
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            await GetAllBooks();
                            TempData["errorMessage"] = "Error on Adding";
                            return View("Index", bookView);

                        }
                    }

                }
                else
                {
                    await GetAllBooks();
                    return View("Index", bookView);
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetBookById(int Id)
        {
            var Data = await _manager.GetBookByIdAsync(Id);
            return Json(Data);
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var data = await _manager.DeleteBookAsync(Id);
            TempData["successMessage"] = data;
            await GetAllBooks();
            return View("Index");
        }
    }
}
