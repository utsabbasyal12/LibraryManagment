using Azure;
using LibraryManagment.EndPoints;
using LibraryManagment.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;

namespace LibraryManagment.Managers
{
    public class BooksManager : IBooksManager
    {
        private HttpClient _httpClient = new HttpClient();

        public BooksManager()
        {
            _httpClient.BaseAddress = new Uri("https://localhost:7201/api/");
        }

        public async Task<List<BookViewModel>> GetAllBooksAsync()
        {
            try
            {
                var Data = await _httpClient.GetAsync(BookManagmentEndpoint.GetAll);
                if (Data.IsSuccessStatusCode)
                {
                    var responseData = await Data.Content.ReadAsStringAsync();
                    var books = JsonConvert.DeserializeObject<List<BookViewModel>>(responseData);
                    return books;
                }
                else
                {
                    return new List<BookViewModel>();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<BookViewModel> GetBookByIdAsync(int Id)
        {
            var Data = await _httpClient.GetAsync(BookManagmentEndpoint.GetById + "?BookId=" + Id);
            if (Data.IsSuccessStatusCode)
            {
                var responseData = await Data.Content.ReadAsStringAsync();
                var books = JsonConvert.DeserializeObject<BookViewModel>(responseData);
                return books;
            }
            else
            {
                return new BookViewModel();
            }
        }
        public async Task<BookViewModel> AddBookAsync(BookViewModel viewModel)
        {
            var Data = await _httpClient.PostAsJsonAsync(BookManagmentEndpoint.Add, viewModel);
            if (Data != null)
            {
                var responseData = await Data.Content.ReadAsStringAsync();
                var books = JsonConvert.DeserializeObject<BookViewModel>(responseData);
                return books;

            }
            else
            {
                return new BookViewModel();
            }
        }
        public async Task<BookViewModel> UpdateBookAsync(BookViewModel viewModel)
        {
            var Data = await _httpClient.PostAsJsonAsync(BookManagmentEndpoint.Update, viewModel);
            if (Data != null)
            {

                var responseData = await Data.Content.ReadAsStringAsync();
                var books = JsonConvert.DeserializeObject<BookViewModel>(responseData);
                return books;
            }
            else
            {
                return new BookViewModel();
            }
        }
        public async Task<string> DeleteBookAsync(int Id)
        {
            var data = await _httpClient.GetAsync(BookManagmentEndpoint.Delete + "?Id=" + Id);
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
