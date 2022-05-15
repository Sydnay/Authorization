using Authorization.Dtos;
using Authorization.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApiWithEF.Repository
{
    public class PlaylistContext : DbContext
    {
        public PlaylistContext(DbContextOptions<PlaylistContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
    }
}
