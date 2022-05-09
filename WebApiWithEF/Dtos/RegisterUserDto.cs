using System.ComponentModel.DataAnnotations;

namespace WebApiWithEF.Dtos
{
    public class RegisterUserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
