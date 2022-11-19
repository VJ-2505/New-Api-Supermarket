using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;
using SuperMarketApi.Models.Enum;
using System.Data;
using System.Linq;
using System;
using SuperMarketApi.Models;

namespace SuperMarketApi.Models
{
    [Serializable]
    public class OrderItemDetail
    {
        public OrderItemDetail()
        {
        }

        public OrderItemDetail(int OrderItemId, int? billId, int OrderItemType, double qty, double? price, double? cgst, double? sgst, double? igst, System.DateTime date, POSDbContext contextOptions)
        {
            OrderItemId = OrderItemId;
            BillId = billId;
            OrderItemType = OrderItemType;
            Quantity = qty;
            UnitPrice = price;
            Tax1 = cgst;
            Tax2 = sgst;
            Amount = igst;
            DateTime = date;
            Date = date;
            db = contextOptions;
        }

        public OrderItemDetail(int OrderItemId, int? billId, int OrderItemType, double qty, double? price, double? tax1, double? tax2, double? amount, double? taxamount, System.DateTime date, POSDbContext contextOptions)
        {
            OrderItemId = OrderItemId;
            BillId = billId;
            OrderItemType = OrderItemType;
            Quantity = qty;
            UnitPrice = price;
            Tax1 = tax1;
            Tax2 = tax2;
            Amount = amount;
            TaxAmount = taxamount;
            DateTime = date;
            Date = date;
            db = contextOptions;
        }
        public int OrderItemDetailId { get; set; }

        public int Id { get; set; }

        [ForeignKey("OrderItem")]
        public int OrderItemId { get; set; }
        public virtual OrderItem OrderItem { get; set; }

        [ForeignKey("ActualProduct")]
        public int? ActualProdId { get; set; }
        public virtual Product ActualProduct { get; set; }

        [ForeignKey("Batch")]
        public int? BatchId { get; set; }
        public virtual Batch Batch { get; set; }

        [ForeignKey("StockBatch")]
        public int? StockBatchId { get; set; }
        public virtual StockBatch StockBatch { get; set; }

        [ForeignKey("Bill")]
        public int? BillId { get; set; }
        public virtual Bill Bill { get; set; }

        public int OrderItemType { get; set; }

        [ForeignKey("StorageStore")]
        public int? StorageStoreId { get; set; }
        public virtual Store StorageStore { get; set; }

        [ForeignKey("StockContainer")]
        public int? ContatinerId { get; set; }
        public virtual StockContainer StockContainer { get; set; }

        public int? ContainerCount { get; set; }

        //[NotMapped]
        //public string OrderItemTypeDesc
        //{
        //    get
        //    {
        //        if (OrderItemType == (int)OrderItemType.Dispatch && Bill != null && Bill.BillType == (int)BillTypeEnum.Sales) return "Delivery";
        //        else
        //          if (OrderItemType == (int)OrderItemType.DispatchLater && Bill != null && Bill.BillType == (int)BillTypeEnum.Sales) return "DeliverLater";
        //        else
        //            return System.Enum.GetName(typeof(OrderItemType), OrderItemType);
        //    }
        //}

        [NotMapped]
        public double GrossQuantity { get; set; }

        public double Quantity { get; set; }

        public double? UnitPrice { get; set; }
        //public double? CGST { get; set; }
        //public double? SGST { get; set; }
        //public double? IGST { get; set; }
        public double? Tax1 { get; set; }
        public double? Tax2 { get; set; }
        public double? Amount { get; set; }
        public double? TaxAmount { get; set; }

        [Column(TypeName = "Date")]
        public System.DateTime? Date { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime? DateTime { get; set; }

        //[ForeignKey("RelatedOrder")]
        public int? RelatedOrderId { get; set; }
        // public virtual Order RelatedOrder { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? CreatedDate { get; set; }

        [ForeignKey("User")]
        public int? CreatedBy { get; set; }
        public virtual Contact User { get; set; }

        [NotMapped]
        public int? DispatchStorageId { get; set; }
        [NotMapped]
        public string DispatchStorageName { get; set; }

        [NotMapped]
        public int? ReceiveStorageId { get; set; }
        [NotMapped]
        public string ReceiveStorageName { get; set; }
        public string OrderItemRefId { get; set; }

        [NotMapped]
        public POSDbContext db { get; set; }

        [NotMapped]
        public double? DispatchQty
        {
            get
            {
                var OrderItemDetail = db.OrderItemDetails.Where(op => op.BillId == BillId && op.Id == Id && op.OrderItemType == (int)SuperMarketApi.Models.Enum.OrderItemType.Dispatch).FirstOrDefault();
                if (OrderItemDetail == null)
                    return null;
                else
                    return OrderItemDetail.Quantity;
            }
        }

        [NotMapped]
        public double? DispatchOpen
        {
            get
            {
                var OrderItemDetail = db.OrderItemDetails.Where(op => op.BillId == BillId && op.Id == Id && op.OrderItemType == (int)SuperMarketApi.Models.Enum.OrderItemType.Dispatch).FirstOrDefault();
                if (OrderItemDetail == null)
                    return null;
                else
                {
                    // var recOrderItemDetail = db.OrderItemDetails.Where(op => op.BillId == BillId && op.OrderItemId == OrderItemId && op.OrderItemType == (int)OrderItemType.Receive).FirstOrDefault();
                    //if (recOrderItemDetail == null)
                    //    return OrderItemDetail.Quantity;
                    //else
                    //    return OrderItemDetail.Quantity - recOrderItemDetail.Quantity;
                    return DispatchQty - (ReceiveQty + ReturnQty);
                }
            }
        }

        [NotMapped]
        public double? ReturnQty
        {
            get
            {
                if (Bill.BillType == 2)
                {
                    var OrderItemDetail = db.OrderItemDetails.Where(op => op.BillId == BillId && op.Id == Id && op.OrderItemType == (int)SuperMarketApi.Models.Enum.OrderItemType.Return).FirstOrDefault();
                    if (OrderItemDetail == null)
                        return 0;
                    else
                        return OrderItemDetail.Quantity;
                }
                else
                {
                    var OrderItemDetail = db.OrderItemDetails.Where(op => op.BillId == BillId && op.Id == Id && op.OrderItemType == (int)SuperMarketApi.Models.Enum.OrderItemType.Return);
                    if (OrderItemDetail.Count() == 0)
                        return 0;
                    else
                        return OrderItemDetail.Sum(op => op.Quantity);
                }
            }
        }

        [NotMapped]
        public double? ReceiveQty
        {
            get
            {
                var OrderItemDetail = db.OrderItemDetails.Where(op => op.BillId == BillId && op.Id == Id && op.OrderItemType == (int)SuperMarketApi.Models.Enum.OrderItemType.Receive).FirstOrDefault();
                if (OrderItemDetail == null)
                    return 0;
                else
                    return OrderItemDetail.Quantity;
            }
        }
        public double DiscAmount { get; set; }

        public double DiscPercent { get; set; }
        public double DiscPerQty { get; set; }

        [NotMapped]
        public string RelatedOrderNO { get; set; }

        [ForeignKey("AutoOrder")]
        public int? AutoOrderId { get; set; }
        public virtual AutoOrder AutoOrder { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [ForeignKey("VarianceReason")]
        public string VarianceReasonStr { get; set; }
        public virtual EnumVal VarianceReason { get; set; }

        public string VarianceReasonDesc { get; set; }

    }
}
