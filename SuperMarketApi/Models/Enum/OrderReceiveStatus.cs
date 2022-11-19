using System;
namespace SuperMarketApi.Models.Enum
{
    public enum OrderReceiveStatus
    {
        Open = 1,
        Partial = 2,
        Closed = 3,
        ReviewClosed = 4,
        // All = 5
    };
}
