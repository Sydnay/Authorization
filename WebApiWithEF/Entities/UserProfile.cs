namespace Authorization.Entities
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        //1:1 User:Profile
        public Guid UserId { get; set; }
        public User User { get; set; }
        //1:n Profile:Playlist
        public List<Playlist> Playlists { get; set; }

        public DateTime? Birthday { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}
