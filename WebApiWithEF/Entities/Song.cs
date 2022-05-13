<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;

namespace Authorization.Entities
{
    public class Song
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Singer { get; set; }
        //n:n LikedLists:Songs
        public List<Playlist> Playlists { get; set; }
=======
﻿namespace Authorization.Entities
{
    public class Song
    {
        Guid Id { get; set; }
        public string Name { get; set; }
        public string Singer { get; set; }
        //n:n LikedLists:Songs
        public List<LikedList> LikedLists { get; set; }
>>>>>>> 5d6d770f0844806175d90ef977ac5e4809a94fd7
        public DateTime CreatedOn { get; set; }
    }
}
