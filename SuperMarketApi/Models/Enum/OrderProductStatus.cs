using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarketApi.Models.Enum
{
    public enum OrderProductStatus
    {
        Open = 1,
        Dispatched = 2,
        Partial = 3,
        Closed = 4,
        ClosedManually = 5,
        MovedAnotherOrder = 6,
        Cancelled = 7
    }
}
