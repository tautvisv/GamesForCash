namespace MVCWithSignalR.Models.GameDto
{
    public class MessageDto
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public int Count { get; set; }
        public MessageDto(string name, string message, int count)
        {
            Name = name;
            Message = message;
            Count = count;
        }
    }
}