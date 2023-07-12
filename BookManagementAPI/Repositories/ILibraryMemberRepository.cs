using BookManagementAPI.Models;

namespace BookManagementAPI.Repositories
{
    public interface ILibraryMemberRepository
    {
        Task<List<LibraryMembersModel>> GetMembers();
        Task<LibraryMembersModel> GetMemberById(int MemberId);
        Task<LibraryMembersModel> AddMembers(LibraryMembersModel model);
        Task<LibraryMembersModel> UpdateMembers(LibraryMembersModel model);
        Task DeleteMembers(int MemberId);
    }
}
