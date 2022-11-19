using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class OrdProdDetail
    {
        public int OrdProdDetailId { get; set; }

        [ForeignKey("OrderProduct")]
        public int OrderProductId { get; set; }
        public virtual OrderProduct OrderProduct { get; set; }

        [ForeignKey("ActualProduct")]
        public int? ActualProdId { get; set; }
        public virtual Product ActualProduct { get; set; }

        [ForeignKey("Batch")]
        public int? BatchId { get; set; }
        public virtual Batch Batch { get; set; }

        [ForeignKey("Bill")]
        public int? BillId { get; set; }
        public virtual Bill Bill { get; set; }

        public int OrdProdType { get; set; }

        [ForeignKey("StorageStore")]
        public int? StorageStoreId { get; set; }
        public virtual Store StorageStore { get; set; }

        [ForeignKey("StockContainer")]
        public int? ContatinerId { get; set; }
        public virtual StockContainer StockContainer { get; set; }

        public int? ContainerCount { get; set; }

        //[NotMapped]
        //public string OrdProdTypeDesc
        //{
        //    get
        //    {
        //        if (OrdProdType == (int)OrderProductType.Dispatch && Bill != null && Bill.BillType == (int)BillTypeEnum.Sales) return "Delivery";
        //        else
        //          if (OrdProdType == (int)OrderProductType.DispatchLater && Bill != null && Bill.BillType == (int)BillTypeEnum.Sales) return "DeliverLater";
        //        else
        //            return System.Enum.GetName(typeof(OrderProductType), OrdProdType);
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

        //[NotMapped]
        //public double? DispatchQty
        //{
        //    get
        //    {
        //        ApplicationDbContext db = new ApplicationDbContext(System.Web.HttpContext.Current.Session["CustomerDb"].ToString());
        //        var ordProdDetail = db.OrdProdDetails.Where(op => op.BillId == BillId && op.OrderProductId == OrderProductId && op.OrdProdType == (int)OrderProductType.Dispatch).FirstOrDefault();
        //        if (ordProdDetail == null)
        //            return null;
        //        else
        //            return ordProdDetail.Quantity;
        //    }
        //}

        //[NotMapped]
        //public double? DispatchOpen
        //{
        //    get
        //    {
        //        ApplicationDbContext db = new ApplicationDbContext(System.Web.HttpContext.Current.Session["CustomerDb"].ToString());
        //        var ordProdDetail = db.OrdProdDetails.Where(op => op.BillId == BillId && op.OrderProductId == OrderProductId && op.OrdProdType == (int)OrderProductType.Dispatch).FirstOrDefault();
        //        if (ordProdDetail == null)
        //            return null;
        //        else
        //        {
        //            //var recOrdProdDetail = db.OrdProdDetails.Where(op => op.BillId == BillId && op.OrderProductId == OrderProductId && op.OrdProdType == (int)OrderProductType.Receive).FirstOrDefault();
        //            //if (recOrdProdDetail == null)
        //            //    return ordProdDetail.Quantity;
        //            //else
        //            //    return ordProdDetail.Quantity - recOrdProdDetail.Quantity;
        //            return DispatchQty - (ReceiveQty + ReturnQty);
        //        }
        //    }
        //}

        //[NotMapped]
        //public double? ReturnQty
        //{
        //    get
        //    {
        //        ApplicationDbContext db = new ApplicationDbContext(System.Web.HttpContext.Current.Session["CustomerDb"].ToString());
        //        if (Bill.BillType == 2)
        //        {
        //            var ordProdDetail = db.OrdProdDetails.Where(op => op.BillId == BillId && op.OrderProductId == OrderProductId && op.OrdProdType == (int)OrderProductType.Return).FirstOrDefault();
        //            if (ordProdDetail == null)
        //                return 0;
        //            else
        //                return ordProdDetail.Quantity;
        //        }
        //        else
        //        {
        //            var ordProdDetail = db.OrdProdDetails.Where(op => op.BillId == BillId && op.OrderProductId == OrderProductId && op.OrdProdType == (int)OrderProductType.Return);
        //            if (ordProdDetail.Count() == 0)
        //                return 0;
        //            else
        //                return ordProdDetail.Sum(op => op.Quantity);
        //        }
        //    }
        //}

        //[NotMapped]
        //public double? ReceiveQty
        //{
        //    get
        //    {
        //        ApplicationDbContext db = new ApplicationDbContext(System.Web.HttpContext.Current.Session["CustomerDb"].ToString());
        //        var ordProdDetail = db.OrdProdDetails.Where(op => op.BillId == BillId && op.OrderProductId == OrderProductId && op.OrdProdType == (int)OrderProductType.Receive).FirstOrDefault();
        //        if (ordProdDetail == null)
        //            return 0;
        //        else
        //            return ordProdDetail.Quantity;
        //    }
        //}
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