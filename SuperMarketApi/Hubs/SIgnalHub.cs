using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SuperMarketApi.Hubs
{
    public class SIgnalHub : Hub<IHubClient>
    {
        public void AnnounceAll(string message)
        {
            Clients.All.AnnounceAll(message);
        }
        public override Task OnConnectedAsync()
        {
            Clients.Client(Context.ConnectionId).Announce(Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}
