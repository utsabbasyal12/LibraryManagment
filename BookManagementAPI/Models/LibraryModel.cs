using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementAPI.Models
{
    [Table("tblLibrary")]
    public class LibraryMembersModel
    {
        [Key]
        public int MembersId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
