using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class OrderProduct
    {
        public int OrderProductId { get; set; }

        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public double? OrderQuantity { get; set; }
        public double? DispatchedQuantity { get; set; }
        public double? ReceivedQuantity { get; set; }
        public double? ReturnedQuantity { get; set; }
        public double? CancelledQuantity { get; set; }
        public double? ReceiveLaterQuantity { get; set; }

        public double? DispatchLaterQuantity { get; set; }

        [NotMapped]
        public double Quantity { get; set; }
        [NotMapped]
        public double BillType { get; set; }
        [NotMapped]
        public double OpenQuantity
        {
            get
            {
                double openQty = 0;
                if (OrderQuantity == null)
                    return 0;
                if (Order.OrderType == 2)
                {
                    if (OrderQuantity != null)
                        openQty = (double)OrderQuantity;
                    if (DispatchedQuantity != null)
                        openQty -= (double)DispatchedQuantity;
                    if (CancelledQuantity != null)
                        openQty -= (double)CancelledQuantity;
                    if (ReturnedQuantity != null)
                        openQty += (double)ReturnedQuantity;
                }
                else if (Order.OrderType == 1 || Order.OrderType == 3)
                {
                    if (OrderQuantity != null)
                        openQty = (double)OrderQuantity;
                    if (ReceivedQuantity != null)
                        openQty -= (double)ReceivedQuantity;
                    if (ReceiveLaterQuantity != null)
                        openQty -= (double)ReceiveLaterQuantity;
                    if (CancelledQuantity != null)
                        openQty -= (double)CancelledQuantity;
                    if (ReturnedQuantity != null)
                        openQty += (double)ReturnedQuantity;
                }
                else if (Order.OrderType == 6)
                {
                    if (OrderQuantity != null)
                        openQty = (double)OrderQuantity;
                    if (DispatchedQuantity != null)
                        openQty -= (double)DispatchedQuantity;
                    if (DispatchLaterQuantity != null)
                        openQty -= (double)DispatchLaterQuantity;
                    if (CancelledQuantity != null)
                        openQty -= (double)CancelledQuantity;
                    if (ReturnedQuantity != null)
                        openQty += (double)ReturnedQuantity;
                }
                return openQty;
            }
        }

        public double? Price { get; set; }

        public double? TaxAmount { get; set; }
        public double? Tax1 { get; set; }
        public double? Tax2 { get; set; }
        public double? Tax3 { get; set; }
        public double? Tax4 { get; set; }
        public double? Amount { get; set; }

        [NotMapped]
        public double? DispatchAmount
        {
            get
            {
                if (ReturnedQuantity != null)
                {
                    return ((DispatchedQuantity - ReturnedQuantity) * Price);
                }
                else
                {
                    return (DispatchedQuantity * Price);
                }
            }
        }
        public double? DispatchTaxAmount
        {
            get
            {
                if (ReturnedQuantity != null)
                {
                    return ((DispatchedQuantity - ReturnedQuantity) * Price * (Tax1 + Tax2)) / 100;
                }
                else
                {
                    return (DispatchedQuantity * Price * (Tax1 + Tax2)) / 100;
                }
            }
        }

        public double? ReceivedAmount
        {
            get
            {
                return ReceivedQuantity * Price;
            }
        }
        public double? ReceivedTaxAmount
        {
            get
            {
                return (ReceivedQuantity * Price * (Tax1 + Tax2)) / 100;
            }
        }
        public double? ReturnedAmount
        {
            get
            {
                return ReturnedQuantity * Price;
            }
        }
        public double? ReturnedTaxAmount
        {
            get
            {
                return (ReturnedQuantity * Price * (Tax1 + Tax2)) / 100;
            }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? CreatedDate { get; set; }

        [ForeignKey("User")]
        public int? CreatedBy { get; set; }
        public virtual Contact User { get; set; }

        [NotMapped]
        //[ForeignKey("Bill")]
        public int? BillId { get; set; }
        [NotMapped]
        public virtual Bill Bill { get; set; }


        [NotMapped]
        public virtual List<OrdProdDetail> OrdProdDetails { get; set; }

        [NotMapped]
        public int Delta { get; set; }

        public int? Status { get; set; }

        //[NotMapped]
        //public string StatusDesc
        //{
        //    get
        //    {
        //        if (Status != null)
        //            return System.Enum.GetName(typeof(OrderProductStatus), Status);
        //        else
        //            return "";
        //    }
        //}

        [NotMapped]
        public int? DispatchStorageId { get; set; }
        [NotMapped]
        public string DispatchStorageName { get; set; }

        [NotMapped]
        public int? ContainerId { get; set; }
        [NotMapped]
        public string Container { get; set; }
        [NotMapped]
        public double ContainerWeight { get; set; }
        [NotMapped]
        public double? ContainerCount { get; set; }


        public int DiscAmount { get; set; }

        public int DiscPercent { get; set; }

        public double? PendingQty { get; set; }
        public double? CurrentStock { get; set; }

        [ForeignKey("AutoOrder")]
        public int? AutoOrderId { get; set; }
        public virtual AutoOrder AutoOrder { get; set; }

        public double? OrderLevel { get; set; }

        [ForeignKey("StockUpdate")]
        public int? StockUpdateId { get; set; }
        public virtual StockUpdate StockUpdate { get; set; }

        public double? OldStock { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [ForeignKey("VarianceReason")]
        public string VarianceReasonStr { get; set; }
        public virtual EnumVal VarianceReason { get; set; }

        public string VarianceReasonDesc { get; set; }
    }
}