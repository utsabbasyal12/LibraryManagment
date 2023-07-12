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
                    // Handle the error response
                    // For example, throw an exception or return an empty list
                    return new List<BookViewModel>();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
