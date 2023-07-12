using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementAPI.Models
{
    [Table("tblLibraryMember")]
    public class LibraryMembersModel
    {
        [Key]
        public int MemberId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
