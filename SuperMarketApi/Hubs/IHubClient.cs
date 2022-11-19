using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Hubs
{
    public interface IHubClient
    {
        Task AnnounceAll(string message);
        Task Announce(string message);

    }
}
