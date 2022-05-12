namespace Authorization.Entities
{
    public class Song
    {
        Guid Id { get; set; }
        public string Name { get; set; }
        public string Singer { get; set; }
        //n:n LikedLists:Songs
        public List<LikedList> LikedLists { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
