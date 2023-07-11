using System.ComponentModel;

namespace LibraryManagment.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        [DisplayName("Status")]
        public int AvailabilityStatus { get; set; }
    }
}
