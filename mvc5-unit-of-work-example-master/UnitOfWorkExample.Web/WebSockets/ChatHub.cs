using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using MVCWithSignalR.Models.GameDto;
using MVCWithSignalR.WebSockets.Data;

namespace UnitOfWorkExample.Web.WebSockets
{
    public class ChatHub : Hub
    {
        public void SendCoords(MiniItemDto itemDto)
        {
            Clients.All.GetCoords(itemDto);
        }
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(new MessageDto(name, message, UserHandler.ConnectedIds.Count));
        }
        public UserDto[] Wellcome(UserDto player)
        {
            var user = UserHandler.ConnectedIds[Context.ConnectionId];
            user.Name = player.Name;
            user.Color = player.Color;
            Clients.All.addPlayer(player);
            return UserHandler.ConnectedIds.Values.ToArray();
        }
        public override Task OnConnected()
        {
            UserHandler.ConnectedIds.Add(Context.ConnectionId, new UserDto());
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            Clients.All.removePlayer(UserHandler.ConnectedIds[Context.ConnectionId]);
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }
    }
}