using BookManagementAPI.Models;
using BookManagementAPI.Repositories;

namespace BookManagementAPI.Services
{
    public class LibraryMemberService : ILibraryMemberService
    {
        private readonly ILibraryMemberRepository _repository;

        public LibraryMemberService(ILibraryMemberRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<LibraryMembersModel>> GetAllMembers()
        {
            return await _repository.GetMembers();
        }
        public async Task<LibraryMembersModel> GetMemberByIdAsync(int MemberId)
        {
            return await _repository.GetMemberById(MemberId);
        }
        public async Task<LibraryMembersModel> AddMembersAsync(LibraryMembersModel model) 
        {
            return await _repository.AddMembers(model);
        }
        public async Task<LibraryMembersModel> UpdateMembersAsync(LibraryMembersModel model)
        {
            return await _repository.UpdateMembers(model);
        }
        public async Task DeleteMemberAsync(int MemberId)
        {
            await _repository.DeleteMembers(MemberId);
        }
    }
}
