﻿using System.ComponentModel.DataAnnotations;

namespace Library.System.DTOs
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}
