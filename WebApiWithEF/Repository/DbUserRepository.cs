using Microsoft.EntityFrameworkCore;

namespace WebApiWithEF.Repository
{
    public class DbUserRepository : DbContext, IUserRepository
    {
        public DbUserRepository(DbContextOptions<DbUserRepository> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        
        public void AddUser(User user)
        {
            Users.Add(user);
        }
        public User GetUser(string login)
        {
            return Users.FirstOrDefault(user => user.Login.Equals(login));
        }
        public void DeleteUser(string login)
        {
            Users.Remove(GetUser(login));
        }
    }
}
