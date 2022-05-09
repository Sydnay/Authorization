using Microsoft.EntityFrameworkCore;
using WebApiWithEF.Dtos;

namespace WebApiWithEF.Repository
{
    public class MemoryUserRepository
    {
        static List<User> users = new List<User>();

        public User GetUser(string login)
        {
            return users.FirstOrDefault(user => user.Login.Equals(login));
        }
        public void AddUser(User user)
        {
            users.Add(user);
        }
    }
}
