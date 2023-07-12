using BookManagementAPI.Models;
using BookManagementAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryAPIController : ControllerBase
    {
        private readonly ILibraryMemberService _service;

        public LibraryAPIController(ILibraryMemberService service)
        {
            _service = service;
        }
        [HttpGet("GetAllMembers")]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await _service.GetAllMembers();
            return Ok(members);
        }
        [HttpGet("GetMemberById")]
        public async Task<IActionResult> GetMemberById(int MemberId)
        {
            var member = await _service.GetMemberByIdAsync(MemberId);
            return Ok(member);
        }
        [HttpPost("AddMember")]
        public async Task<IActionResult> AddMembers([FromBody] LibraryMembersModel model)
        {
            var data = await _service.AddMembersAsync(model);
            return Ok(data);
        }
        [HttpPost("UpdateMember")]
        public async Task<IActionResult> UpdateMembers([FromBody] LibraryMembersModel model)
        {
            var data = await _service.UpdateMembersAsync(model);
            return Ok(data);
        }
        [HttpGet("DeleteMember")]
        public async Task<IActionResult> DeleteMember(int MemberId)
        {
            await _service.DeleteMemberAsync(MemberId);
            return Ok("Member Deleted Successfully.");
        }
    }
}
