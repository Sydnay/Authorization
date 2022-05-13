﻿using Authorization.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApiWithEF.Repository
{
    public class LikedSongsContext : DbContext, IUserRepository
    {
        public LikedSongsContext(DbContextOptions<LikedSongsContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<LikedList> LikedList { get; set; }
        
        public void AddUser(User user)
        {
            Users.Add(user);
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
