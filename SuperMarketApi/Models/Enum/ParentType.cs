using System;
namespace SuperMarketApi.Models.Enum
{
    public enum ParentType
    {
        Production = 1,
        POSImport = 2,
        Dispatch = 3,
        BulkStockUpdate = 4,
        ComboProduct = 5,
        Wastage = 6,
        Return = 7
    };
}
