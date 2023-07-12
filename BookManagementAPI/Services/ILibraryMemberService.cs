using BookManagementAPI.Models;

namespace BookManagementAPI.Services
{
    public interface ILibraryMemberService
    {
        Task<List<LibraryMembersModel>> GetAllMembers();
        Task<LibraryMembersModel> GetMemberByIdAsync(int MemberId);
        Task<LibraryMembersModel> AddMembersAsync(LibraryMembersModel model);
        Task<LibraryMembersModel> UpdateMembersAsync(LibraryMembersModel model);
        Task DeleteMemberAsync(int MemberId);
    }
}
