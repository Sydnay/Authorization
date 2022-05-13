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

        public async Task AddUser(User user, Profile profile)
        {
            await Users.AddAsync(user);
            await Profiles.AddAsync(profile);
        }
        public User GetUser(string email)
        {
            return Users.FirstOrDefault(user => user.Email.Equals(email));
        }
        public void DeleteUser(string login)
        {
            Users.Remove(GetUser(login));
        }

        internal List<User> GetAllUsers()
        {
            return Users.ToList();
        }
    }
}
