using System.ComponentModel.DataAnnotations;

namespace Library.System.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$",
        ErrorMessage = "Password must be at least 6 characters long, contain at least one uppercase letter, one lowercase letter, and one number.")]
        public string Password { get; set; }
    }
}
