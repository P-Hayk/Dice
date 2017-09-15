using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR;
using System.Linq;
using DiceWebAPI.Util;
using System.Threading.Tasks;

namespace DiceWebAPI
{
    [HubName("gameHub")]

    public class GameHub : Hub
    {
        private readonly static ConnectionMapping<int> _connections =
            new ConnectionMapping<int>();

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;
            int userId = int.Parse(Context.QueryString["uid"]);
            _connections.Add(userId, Context.ConnectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string name = Context.User.Identity.Name;
            int userId = int.Parse(Context.QueryString["uid"]);

            _connections.Remove(userId, Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            string name = Context.User.Identity.Name;
            int userId = int.Parse(Context.QueryString["uid"]);
            if (!_connections.GetConnections(userId).Contains(Context.ConnectionId))
            {
                _connections.Add(userId, Context.ConnectionId);
            }

            return base.OnReconnected();
        }

        public static ConnectionMapping<int> Connections
        {
            get { return _connections; }
        }
    }
}
