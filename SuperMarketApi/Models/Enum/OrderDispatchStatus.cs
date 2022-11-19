using System;
namespace SuperMarketApi.Models.Enum
{
    public enum OrderDispatchStatus
    {
        Open = 1,
        Partial = 2,
        Closed = 3,
        ReviewClosed = 4,
        All = 5
    };
}