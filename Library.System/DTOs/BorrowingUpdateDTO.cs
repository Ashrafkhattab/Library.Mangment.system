using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Library.System.DTOs
{
    public class BorrowingUpdateDTO
    {
        [Required]
        public int Id { get; set; }
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
