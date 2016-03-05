using System.Collections.Generic;
using MVCWithSignalR.Models.GameDto;

namespace MVCWithSignalR.WebSockets.Data
{
    public static class UserHandler
    {
        public static Dictionary<string,UserDto> ConnectedIds = new Dictionary<string, UserDto>();
    }
}