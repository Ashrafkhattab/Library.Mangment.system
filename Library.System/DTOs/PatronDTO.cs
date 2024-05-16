using System.ComponentModel.DataAnnotations;

namespace Library.System.DTOs
{
    public class PatronDTO
    {
        [Required]
        [MinLength(10)]
        public string Name { get; set; }
        [Required]
        [Phone]
        [MinLength(10)]
        public String PhoneNumber { get; set; }

    }
}
