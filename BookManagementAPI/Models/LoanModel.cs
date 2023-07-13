using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementAPI.Models
{
    [Table("tblLoan")]
    public class LoanModel
    {
        [Key]
        public int LoanId { get;set; }
        public int MemberId { get;set; }
        public int BookId { get;set; }
        public DateTime IssueDate { get;set; }
        public DateTime ReturnDate { get;set; }
    }
}
