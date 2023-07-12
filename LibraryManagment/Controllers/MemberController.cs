
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
        [HttpPost]
        public async Task<IActionResult> Create(MembersViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                if(viewModel.MemberId != 0)
                {
                    var data = await _manager.UpdateMemberAsync(viewModel);
                    if (data != null)
                    {
                        TempData["successMessage"] = "Member Updated Successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        await GetAllMembers();
                        TempData["errorMessage"] = "Error on Updating";
                        return View("Index", viewModel);

                    }
                }
                else
                {
                    var data = await _manager.AddMembersAsync(viewModel);
                    if (data != null)
                    {
                        TempData["successMessage"] = "Member Created Successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        await GetAllMembers();
                        TempData["errorMessage"] = "Error on Adding";
                        return View("Index", viewModel);

                    }
                }
            }
            else
            {
                await GetAllMembers();
                return View("Index", viewModel);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetMemberById(int Id)
        {
            var Data = await _manager.GetMemberByIdAsync(Id);
            return Json(Data);
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var data = await _manager.DeleteMemberAsync(Id);
            TempData["successMessage"] = data;
            await GetAllMembers();
            return View("Index");
        }
    }
}
