
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
        public DateTime CreatedOn { get; set; }
    }
}
