using Authorization.Entities;

namespace Authorization.Dtos
{
    public static class ProfileInfo
    {
        public static ProfileInfoDto ToProfileInfo(this Profile profile)
        {
            return new ProfileInfoDto
            {
                Name = profile.Name,
                Gender = profile.Gender,
                Birthday = profile.Birthday
            };
        }
    }
}
