namespace Authorization.Entities
{
    public interface IUserRepository
    {
        void AddUser(User user, Profile profile);
        User GetUser(string login);
        void DeleteUser(string login);
    }
}
