﻿using System.ComponentModel.DataAnnotations;

namespace WebApiWithEF.Dtos
{
    public class RegisterUserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Login { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
