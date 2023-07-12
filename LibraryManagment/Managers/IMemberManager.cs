using LibraryManagment.ViewModels;

namespace LibraryManagment.Managers
{
    public interface IMemberManager
    {
        Task<List<MembersViewModel>> GetAllMembersAsync();
        Task<MembersViewModel> GetMemberByIdAsync(int Id);
        Task<MembersViewModel> AddMembersAsync(MembersViewModel model);
        Task<MembersViewModel> UpdateMemberAsync(MembersViewModel model);
        Task<string> DeleteMemberAsync(int Id);

    }
}