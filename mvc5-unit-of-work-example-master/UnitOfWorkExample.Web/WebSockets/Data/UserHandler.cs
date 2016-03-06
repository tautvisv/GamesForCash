using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using MVCWithSignalR.Models.GameDto;

namespace UnitOfWorkExample.Web.WebSockets.Data
{
    public static class UserHandler
    {
        public static Dictionary<string,UserDto> ConnectedIds = new Dictionary<string, UserDto>();
    }
    public interface IUserIdProvider
    {
        string GetUserId(IRequest request);
    }
}