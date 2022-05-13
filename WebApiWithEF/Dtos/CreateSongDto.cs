using System.ComponentModel.DataAnnotations;

namespace Authorization.Dtos
{
    public class CreateSongDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Singer { get; set; }
    }
}
