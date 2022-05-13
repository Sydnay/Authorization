namespace Authorization.Entities
{
    public class Playlist
    {
        public Guid Id { get; set; }
        //1:n Profile:Playlist
        public Guid OwnerId { get; set; }
        public Profile Owner { get; set; }
        //n:n LikedLists:Songs
        public List<Song> Songs { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
