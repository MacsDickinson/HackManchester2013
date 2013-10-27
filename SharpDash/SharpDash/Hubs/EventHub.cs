using Microsoft.AspNet.SignalR;

namespace SharpDash
{
    public class EventHub : Hub
    {
        public void Send(string id)
        {
            Clients.All.broadcastEventId(id);
        }
    }
}