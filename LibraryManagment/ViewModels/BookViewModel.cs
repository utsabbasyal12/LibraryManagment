using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LibraryManagment.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        [Required(ErrorMessage ="Requried!")]
        public string Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        [DisplayName("Status")]
        public int AvailabilityStatus { get; set; }
    }
    public enum Status
    {
        Available = 1,
        Reserved = 2
    }
}
