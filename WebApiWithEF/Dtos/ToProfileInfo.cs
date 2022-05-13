using Authorization.Entities;

namespace Authorization.Dtos
{
    public static class ToProfileInfo
    {
        public static ProfileInfoDto ProfileInfo(this Profile profile)
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
