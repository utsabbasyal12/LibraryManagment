using LibraryManagment.EndPoints;
using LibraryManagment.ViewModels;
using Newtonsoft.Json;

namespace LibraryManagment.Managers
{
    public class MemberManager : IMemberManager
    {
        private HttpClient _httpClient = new HttpClient();

        public MemberManager()
        {
            _httpClient.BaseAddress = new Uri("https://localhost:7201/api/");
        }
        public async Task<List<MembersViewModel>> GetAllMembersAsync()
        {
            var Data = await _httpClient.GetAsync(LibraryManagmentEndpoints.GetAll);
            if(Data.IsSuccessStatusCode)
            {
                var responseData = await Data.Content.ReadAsStringAsync();
                var members = JsonConvert.DeserializeObject<List<MembersViewModel>>(responseData);
                return members;
            }
            else
            {
                return new List<MembersViewModel>();
            }
        }
        public async Task<MembersViewModel> GetMemberByIdAsync(int Id)
        {
            var Data = await _httpClient.GetAsync(LibraryManagmentEndpoints.GetById + "?MemberId=" + Id);
            if(Data.IsSuccessStatusCode)
            {
                var responseData = await Data.Content.ReadAsStringAsync();
                var members = JsonConvert.DeserializeObject<MembersViewModel>(responseData);
                return members;
            }
            else
            {
                return new MembersViewModel();
            }
        }
        public async Task<MembersViewModel> AddMembersAsync(MembersViewModel model)
        {
            var Data = await _httpClient.PostAsJsonAsync(LibraryManagmentEndpoints.Add, model);
            if(Data != null)
            {
                var responseData = await Data.Content.ReadAsStringAsync();
                var members = JsonConvert.DeserializeObject<MembersViewModel>(responseData);
                return members;
            }
            else
            {
                return new MembersViewModel();
            }
        }
        public async Task<MembersViewModel> UpdateMemberAsync(MembersViewModel model)
        {
            var Data = await _httpClient.PostAsJsonAsync(LibraryManagmentEndpoints.Update,model);
            if(Data != null)
            {
                var responseData = await Data.Content.ReadAsStringAsync();
                var members = JsonConvert.DeserializeObject<MembersViewModel>(responseData);
                return members;
            }
            else
            {
                return new MembersViewModel();
            }
        }
        public async Task<string> DeleteMemberAsync(int Id)
        {
            var Data = await _httpClient.GetAsync(LibraryManagmentEndpoints.Delete + "?MemberId=" + Id);
            if (Data.IsSuccessStatusCode)
            {
                var responseData = await Data.Content.ReadAsStringAsync();
                return responseData;
            }
            else
            {
                return "";
            }
        }
    }
}
