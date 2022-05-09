namespace WebApiWithEF.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUser(string login);
        void DeleteUser(string login);
    }
}
