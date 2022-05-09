namespace WebApiWithEF
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
