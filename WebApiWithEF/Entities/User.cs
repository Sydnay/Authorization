namespace Authorization.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        //1:1 User:Profile
        public Profile Profile { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public enum Role
    {
        DefaultUser,
        Admin
    }
}
