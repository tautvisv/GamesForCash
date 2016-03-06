using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using MVCWithSignalR.Models.GameDto;
using UnitOfWorkExample.Web.WebSockets.Data;

namespace UnitOfWorkExample.Web.WebSockets
{

    public class ChatHub : Hub
    {
        private readonly static ConnectionMapping<string> Connections =
            new ConnectionMapping<string>();

        public void SendCoords(MiniItemDto itemDto)
        {
            Clients.All.GetCoords(itemDto);
        }
        public void Send(string name, string message, string who)
        {
            if (string.IsNullOrEmpty(who))
            {
                return;
            }
            // Call the broadcastMessage method to update clients.
            //Clients.All.broadcastMessage(new MessageDto(name, message, UserHandler.ConnectedIds.Count));

            //Clients.User(UserHandler.ConnectedIds.FirstOrDefault().Key).broadcastMessage(new MessageDto(name, message, UserHandler.ConnectedIds.Count));
            
            foreach (var connectionId in Connections.GetConnections(who))
            {
                Clients.Client(connectionId).broadcastMessage(new MessageDto(name, message, UserHandler.ConnectedIds.Count));
            }
            

            // Clients.User("asd").broadCastMessage("test", "teste from send", 5);
        }
        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;

            Connections.Add(name, Context.ConnectionId);
            UserHandler.ConnectedIds.Add(Context.ConnectionId, new UserDto());

            return base.OnConnected();
        }

        public bool ValidateCheckersMove()
        {
            return true;
        }
        public UserDto[] Wellcome(UserDto player)
        {
            var user = UserHandler.ConnectedIds[Context.ConnectionId];
            user.Name = player.Name;
            user.Color = player.Color;
            Clients.All.addPlayer(player);
            return UserHandler.ConnectedIds.Values.ToArray();
        }


        public override Task OnDisconnected(bool stopCalled)
        {
            string name = Context.User.Identity.Name;

            Connections.Remove(name, Context.ConnectionId);

            Clients.All.removePlayer(UserHandler.ConnectedIds[Context.ConnectionId]);
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }
        
        public void SendChatMessage(string who, string message)
        {
            string name = Context.User.Identity.Name;

            foreach (var connectionId in Connections.GetConnections(who))
            {
                Clients.Client(connectionId).addChatMessage(name + ": " + message);
            }
        }


        public override Task OnReconnected()
        {
            string name = Context.User.Identity.Name;

            if (!Connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                Connections.Add(name, Context.ConnectionId);
            }

            return base.OnReconnected();
        }
    }
}