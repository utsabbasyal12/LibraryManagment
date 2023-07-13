using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagment.ViewModels
{
    public class LoanViewModel
    {
        public int LoanId { get; set; }
        public int MemberId { get; set; }
        public string? MemberName { get; set; } 
        public int BookId { get; set; }
        public string? BookName { get; set; }

        [BindProperty, DataType(DataType.Date)]
        public DateTime IssueDate { get; set; } = DateTime.Now;

        [BindProperty, DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; } = DateTime.Now;
    }
}
