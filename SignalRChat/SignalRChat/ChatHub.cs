using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalRChat
{
    public static class UserHandler
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();
    }

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
    public class ChatHub : Hub
    {
        public void SendCoords(Coordinates coor)
        {
            Clients.All.GetCoords(coor);
        }
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(new MessageDto(name, message, UserHandler.ConnectedIds.Count));
        }
        public override Task OnConnected()
        {
            UserHandler.ConnectedIds.Add(Context.ConnectionId);
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }
    }

    public class Coordinates
    {
        public int top { get; set; }
        public int left { get; set; }
    }
}