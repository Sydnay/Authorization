using System.ComponentModel.DataAnnotations;

namespace Authorization.Dtos
{
    public class UpdateSongDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Singer { get; set; }
    }
}
