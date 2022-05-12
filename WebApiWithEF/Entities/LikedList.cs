namespace Authorization.Entities
{
    public class LikedList
    {
        public Guid Id { get; set; }
        //1:1 Profile:LikedList
        public Guid OwnerId { get; set; }
        public UserProfile Owner { get; set; }
        //n:n LikedLists:Songs
        public List<Song> Songs { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
