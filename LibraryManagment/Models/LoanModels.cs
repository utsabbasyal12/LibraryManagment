namespace LibraryManagment.Models
{
    public class LoanModels
    {
        public int LoanId { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
