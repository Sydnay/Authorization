namespace WebApiWithEF.Dtos
{
    static public class ConvertToDto
    {
        static public UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Login = user.Login,
                CreatedOn = user.CreatedOn
            };
        }
    }
}
