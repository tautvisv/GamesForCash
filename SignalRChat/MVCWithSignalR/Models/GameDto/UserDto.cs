namespace MVCWithSignalR.Models.GameDto
{
    public class UserDto
    {
        public UserDto(string name)
        {
            Name = name;
        }

        public UserDto()
        {
        }

        public string Name { get; set; }
        public string Color { get; set; }
    }
}