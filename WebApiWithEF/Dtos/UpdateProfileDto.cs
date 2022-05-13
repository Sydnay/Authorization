using Authorization.Entities;

namespace Authorization.Dtos
{
    public class UpdateProfileDto
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Birthday { get; set; }
    }
    
}
