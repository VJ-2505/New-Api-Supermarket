using System;
namespace SuperMarketApi.Models.Enum
{
    public enum BillReceiveStatus
    {
        Returned = -1,
        Open = 1,
        Partial = 2,
        Closed = 3,
        All = 4
    };
}