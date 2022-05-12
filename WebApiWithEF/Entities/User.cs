namespace Authorization.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        //1:n Users:Role
        public int RoleId { get; set; }
        public string Role { get; set; }
        //1:1 User:Profile
        public UserProfile Profile { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
