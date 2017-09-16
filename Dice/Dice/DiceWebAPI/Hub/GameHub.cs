using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR;
using System.Linq;
using DiceWebAPI.Util;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Dice.BLL.Entities;

namespace DiceWebAPI
{
    [HubName("gameHub")]

    public class GameHub : Hub
    {
        private readonly static ConnectionMapping<int> _connections =
            new ConnectionMapping<int>();

        public override Task OnConnected()
        {
            int playerId = JsonConvert.DeserializeObject<PlayerSessionDTO>(Context.RequestCookies["a"].Value).PlayerId;
           
            _connections.Add(playerId, Context.ConnectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            int playerId = JsonConvert.DeserializeObject<PlayerSessionDTO>(Context.RequestCookies["a"].Value).PlayerId;

            _connections.Remove(playerId, Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            int playerId = JsonConvert.DeserializeObject<PlayerSessionDTO>(Context.RequestCookies["a"].Value).PlayerId;
            if (!_connections.GetConnections(playerId).Contains(Context.ConnectionId))
            {
                _connections.Add(playerId, Context.ConnectionId);
            }

            return base.OnReconnected();
        }

        public static ConnectionMapping<int> Connections
        {
            get { return _connections; }
        }
    }
}
