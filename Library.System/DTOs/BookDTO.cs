using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.System.DTOs
{
    public class BookDTO
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; }
        [Required]
        [MinLength(3)]
        public string Author { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Publication Year")]
        public DateTime PublicationYear { get; set; }
        [Required]
        public string ISBN { get; set; }

    }
}
