using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagment.Models
{
    [Table("tblBooks")]
    public class BooksModel
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int AvailabilityStatus { get; set; }
    }
}
