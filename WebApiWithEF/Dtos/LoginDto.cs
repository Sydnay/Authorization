﻿using System.ComponentModel.DataAnnotations;

namespace Authorization.Models
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Login { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
