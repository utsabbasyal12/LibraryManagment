using LibraryManagment.EndPoints;
using LibraryManagment.ViewModels;
using Newtonsoft.Json;

namespace LibraryManagment.Managers
{
    public class LoanManager : ILoanManager
    {
        private HttpClient _httpClient = new HttpClient();
        public LoanManager()
        {
            _httpClient.BaseAddress = new Uri("https://localhost:7201/api/");
        }

        public async Task<List<LoanViewModel>> GetAllLoanAsync()
        {
            var Data = await _httpClient.GetAsync(LoanEndpoint.GetAll);
            if (Data.IsSuccessStatusCode)
            {
                var responseData = await Data.Content.ReadAsStringAsync();
                var loans = JsonConvert.DeserializeObject<List<LoanViewModel>>(responseData);
                return loans;
            }
            else
            {
                return new List<LoanViewModel>();
            }
        }
        public async Task<LoanViewModel> GetLoanByIdAsync(int Id)
        {
            var Data = await _httpClient.GetAsync(LoanEndpoint.GetById + "?LoanId=" + Id);
            if (Data.IsSuccessStatusCode)
            {
                var responseData = await Data.Content.ReadAsStringAsync();
                var loan = JsonConvert.DeserializeObject<LoanViewModel>(responseData);
                return loan;
            }
            else
            {
                return new LoanViewModel();
            }
        }
        public async Task<LoanViewModel> AddLoanAsync(LoanViewModel viewModel)
        {
            var Data = await _httpClient.PostAsJsonAsync(LoanEndpoint.Add, viewModel);
            if (Data != null)
            {
                var responseData = await Data.Content.ReadAsStringAsync();
                var loans = JsonConvert.DeserializeObject<LoanViewModel>(responseData);
                return loans;

            }
            else
            {
                return new LoanViewModel();
            }
        }
        public async Task<LoanViewModel> UpdateLoanAsync(LoanViewModel viewModel)
        {
            var Data = await _httpClient.PostAsJsonAsync(LoanEndpoint.Update, viewModel);
            if (Data != null)
            {

                var responseData = await Data.Content.ReadAsStringAsync();
                var loans = JsonConvert.DeserializeObject<LoanViewModel>(responseData);
                return loans;
            }
            else
            {
                return new LoanViewModel();
            }
        }
        public async Task<string> DeleteLoanAsync(int Id)
        {
            var data = await _httpClient.GetAsync(LoanEndpoint.Delete + "?LoanId=" + Id);
            if (data.IsSuccessStatusCode)
            {
                var responseData = await data.Content.ReadAsStringAsync();
                return responseData;
            }
            else
            {
                return "";
            }
        }
    }
}
