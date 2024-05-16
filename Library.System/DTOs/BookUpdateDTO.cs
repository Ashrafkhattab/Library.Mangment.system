using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Library.System.DTOs
{
    public class BookUpdateDTO
    {
        [Required]
        public int id {  get; set; }
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
