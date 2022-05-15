using Authorization.Entities;
using System.ComponentModel.DataAnnotations;

namespace WebApiWithEF.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        [Required]
        [Range(0, 1)]
        public Gender Gender { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
