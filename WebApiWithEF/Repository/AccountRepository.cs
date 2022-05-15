using Authorization.Dtos;
using Authorization.Entities;

namespace Authorization.Repository
{
    public class AccountRepository
    {
        private PlaylistContext repository;
        public AccountRepository(PlaylistContext repository)
        {
            this.repository = repository;
        }
        public async Task AddUser(User user, Profile profile)
        {
            await repository.Users.AddAsync(user);
            await repository.Profiles.AddAsync(profile);
            await repository.SaveChangesAsync();
        }
        public async Task UpdateRole(User user, string role)
        {
            user.Role = role;

            repository.Users.Update(user);
            await repository.SaveChangesAsync();
        }
        public async Task UpdateProfile(Profile profile, UpdateProfileDto profileDto)
        {
            profile.Gender = profileDto.Gender;
            profile.Name = profileDto.Name is null ? profile.Name : profileDto.Name;
            profile.Birthday = profileDto.Birthday is null ? profile.Birthday : profileDto.Birthday;

            repository.Profiles.Update(profile);
            await repository.SaveChangesAsync();
        }
        public async Task<User> GetUser(string email)
        {
            return await repository.Users.FirstOrDefaultAsync(user => user.Email.Equals(email));
        }
        public async Task<Profile> GetProfile(string email)
        {
            return await repository.Profiles.FirstOrDefaultAsync(user => user.User.Email.Equals(email));
        }
        public async Task DeleteUser(string login)
        {
            repository.Users.Remove(await GetUser(login));
            await repository.SaveChangesAsync();
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await repository.Users.ToListAsync();
        }
    }
}
