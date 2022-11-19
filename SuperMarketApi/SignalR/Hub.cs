using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.SignalR
{
    public class MyHub : Hub
    {
        public void Announce()
        {
            //Clients.All.();
        }
    }
}
