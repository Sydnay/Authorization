namespace Authorization.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
<<<<<<< HEAD
        public string Role { get; set; }
        //1:1 User:Profile
        public Profile Profile { get; set; }
=======
        //1:n Users:Role
        public int RoleId { get; set; }
        public string Role { get; set; }
        //1:1 User:Profile
        public UserProfile Profile { get; set; }
>>>>>>> 5d6d770f0844806175d90ef977ac5e4809a94fd7

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedOn { get; set; }
    }
<<<<<<< HEAD
    public enum Role
    {
        DefaultUser,
        Admin
    }
=======
>>>>>>> 5d6d770f0844806175d90ef977ac5e4809a94fd7
}
