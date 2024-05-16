using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.System.DTOs
{
    public class BorrowingDTO
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Borrowing Date")]
        public DateTime BorrowingDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Return Date")]
        public DateTime ReturnDate { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int PatronId { get; set; }
    }
}
