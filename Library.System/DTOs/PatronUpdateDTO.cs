using System.ComponentModel.DataAnnotations;

namespace Library.System.DTOs
{
    public class PatronUpdateDTO
    {
        [Required]
        public int id { get; set; }
        [Required]
        [MinLength(10)]
        public string Name { get; set; }
        [Required]
        [Phone]
        [MinLength(10)]
        public String PhoneNumber { get; set; }
    }
}
