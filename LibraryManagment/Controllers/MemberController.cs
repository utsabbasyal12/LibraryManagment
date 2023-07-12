
using LibraryManagment.Managers;
using LibraryManagment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberManager _manager;

        public MemberController(IMemberManager manager)
        {
            _manager = manager;
        }
        public async Task GetAllMembers()
        {
            var Data = await _manager.GetAllMembersAsync(); 
            ViewBag.Members = Data;
        }
        [HttpGet]
        public async Task<IActionResult> Index(MembersViewModel viewModel)
        {
            await GetAllMembers();
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
