using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace SuperMarketApi.Models
{
    [Serializable]
    public class StockUpdate
    {
        public int StockUpdateId { get; set; }

        //[ForeignKey("BulkStockUpdate")]
        //public int? BulkStockUpdateId { get; set; }
        //public virtual BulkStockUpdate BulkStockUpdate { get; set; }

        [ForeignKey("StockBatch")]
        public int StockBatchId { get; set; }
        public virtual StockBatch StockBatch { get; set; }

        //[ForeignKey("Stock")]
        //public int StockId { get; set; }
        //public virtual Stock Stock { get; set; }

        public double UpdatedQty { get; set; }
        public double OldQty { get; set; }
        public double OldQtyAct { get; set; }

        [Column(TypeName = "Date")]
        public System.DateTime? StockUpdDate { get; set; }

        public System.DateTime? StockUpdDateTime { get; set; }

        public System.DateTime CreatedDate { get; set; }

        //[ForeignKey("StockUpdateType")]
        //public int? StockUpdateTypeId { get; set; }
        //public virtual StockUpdateType StockUpdateType { get; set; }

        [ForeignKey("StockContainer")]
        public int? StockContainerId { get; set; }
        public virtual StockContainer StockContainer { get; set; }


        public double? GrossQty { get; set; }
        public double? ContainerWight { get; set; }
        public double? ContainerCount { get; set; }

        public bool? IsManual { get; set; }

        //public int? StockId { get; set; }
        //public int? ProductId { get; set; }

        //public string ProdName { get; set; }
        //public string CategoryName { get; set; }
        //public int ProductTypeId { get; set; }
        //public double? Quantity { get; set; }
        //public double? ReorderLevel { get; set; }

        //public int? StoreId { get; set; }

        public string GrossQtyText { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public string Actions { get; set; }

    }
}
