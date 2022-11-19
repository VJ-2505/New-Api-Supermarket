using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarketApi.Models.Enum
{
    public enum OrderItemType
    {
        Order = 1,
        Dispatch = 2,
        Receive = 3,
        Return = 4,
        Cancel = 5,
        MovedAnotherOrder = 6,
        ManualClosed = 7,
        CreatedByAnotherOrder = 8,
        ManualClosed_Bill = 9,
        ReceiveLater = 10,
        DispatchLater = 11
    }
}
