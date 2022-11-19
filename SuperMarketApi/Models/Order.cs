using SuperMarketApi.Models;
using SuperMarketApi.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class Order
    {
        public int Id { get; set; }//------------------
        
        public int OrderNo { get; set; }//------------------

        //[ForeignKey("OrderType")]
        public int OrderType { get; set; }
        //public virtual OrderType OrderType { get; set; }
        public string InvoiceNo { get; set; }//------------------

        public int? SourceId { get; set; }//------------------
        public string AggregatorOrderId { get; set; }//------------------
        public string UPOrderId { get; set; }//------------------

        [ForeignKey("Store")]
        public int? StoreId { get; set; }//------------------
        public virtual Store Store { get; set; }

        [ForeignKey("DeliveryStore")]
        public int? DeliveryStoreId { get; set; }//------------------
        public virtual Store DeliveryStore { get; set; }


        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }        
       
        [ForeignKey("CustomerAddress")]
        public int? CustomerAddressId { get; set; }
        public virtual CustomerAddress CustomerAddress { get; set; }

        public int OrderStatusId { get; set; }//------------------
        public int? PreviousStatusId { get; set; }//------------------

        public double BillAmount { get; set; }//------------------
        public double PaidAmount { get; set; }//------------------
        public double RefundAmount { get; set; }
        public string Source { get; set; }//------------------

        public double Tax1 { get; set; }//------------------
        public double Tax2 { get; set; }//------------------
        public double Tax3 { get; set; }//------------------

        public int BillStatusId { get; set; }//------------------

        public int? SplitTableId { get; set; }
        public double DiscPercent { get; set; }//------------------
        public double DiscAmount { get; set; }//------------------
        public bool IsAdvanceOrder { get; set; }//------------------
        public string CustomerData { get; set; }//------------------

        //[ForeignKey("Cashier")]
        //public int CashierId { get; set; }
        //public virtual User Cashier { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderedDateTime { get; set; }//------------------

        [Column(TypeName = "Date")]
        public DateTime OrderedDate { get; set; }//------------------
        [Column(TypeName = "Date")]
        public DateTime? DeliveryDate { get; set; }//------------------

        [Column(TypeName = "Date")]
        public DateTime? DeliveredDate { get; set; }//------------------

        public TimeSpan OrderedTime { get; set; }//------------------

        [DataType(DataType.Date)]
        public DateTime? DeliveryDateTime { get; set; }//------------------

        [DataType(DataType.Date)]
        public DateTime? DeliveredDateTime { get; set; }//------------------

        [DataType(DataType.Date)]
        public DateTime BillDateTime { get; set; }//------------------

        [Column(TypeName = "Date")]
        public DateTime BillDate { get; set; }//------------------

        public string Note { get; set; }//------------------
        public string OrderStatusDetails { get; set; }
        public string RiderStatusDetails { get; set; }
        public bool Closed { get; set; }//------------------
        public string OrderJson { get; set; }
        public string ItemJson { get; set; }
        public string ChargeJson { get; set; }
        public double? Charges { get; set; }
        public double? OrderDiscount { get; set; }
        public double? OrderTaxDisc { get; set; }
        public double? OrderTotDisc { get; set; }
        public double? AllItemDisc { get; set; }
        public double? AllItemTaxDisc { get; set; }
        public double? AllItemTotalDisc { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }//??????????????
        public virtual User User { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }//------------------
        public virtual Company Company { get; set; }


        /////////////////////////////////////dzgvdv/////////////////////////////////////

   

        public int? AutoOrderId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? CreatedDate { get; set; }


        /***** DateTime of Complete Dispatch *****/
        [NotMapped]
        [DataType(DataType.Date)]
        public System.DateTime? DispatchedDate { get; set; }

        /***** DateTime of Complete Receive *****/
        [NotMapped]
        [DataType(DataType.Date)]
        public System.DateTime? ReceivedDate { get; set; }

        [ForeignKey("SuppliedBy")]
        public int SuppliedById { get; set; }
        public virtual Contact SuppliedBy { get; set; }

        [ForeignKey("OrderedBy")]
        public int? OrderedById { get; set; }
        public virtual Contact OrderedBy { get; set; }

        [NotMapped]
        public virtual List<OrderItem> OrderItems { get; set; }
        [NotMapped]
        public virtual List<Lazy<OrderItem>> Items { get; set; }

        [NotMapped]
        public virtual List<OrderItemDetail> OrderItemDetails { get; set; }

        [NotMapped]
        public double Advance { get; set; }
        [NotMapped]
        public double BilledAmount { get; set; }

        public int? OrderStatus { get; set; }
        public int? DispatchStatus { get; set; }
        public int? ReceiveStatus { get; set; }
        public int? CancelStatus { get; set; }

        public bool SpecialOrder { get; set; }
        [NotMapped]
        public string SpecialOrderDesc
        {
            get
            {
                if (SpecialOrder == true)
                    return "Yes";
                else
                    return "No";
            }

        }
        [NotMapped]
        public string DispatchStatusDesc
        {
            get
            {
                if (DispatchStatus != null)
                    return System.Enum.GetName(typeof(OrderDispatchStatus), DispatchStatus);
                else
                    return null;
            }

        }
        [NotMapped]
        public string ReceiveStatusDesc
        {
            get
            {
                if (ReceiveStatus != null)
                    return System.Enum.GetName(typeof(OrderReceiveStatus), ReceiveStatus);
                else
                    return null;
            }

        }
        [NotMapped]
        public string CancelStatusDesc
        {
            get
            {
                if (CancelStatus != null)
                    return System.Enum.GetName(typeof(OrderCancelStatus), CancelStatus);
                else
                    return null;
            }

        }
        [ForeignKey("WipStatusEnum")]
        public string WipStatus { get; set; }
        public virtual EnumVal WipStatusEnum { get; set; }

        [ForeignKey("ProdStatusEnum")]
        public string ProdStatus { get; set; }
        public virtual EnumVal ProdStatusEnum { get; set; }

        [NotMapped]
        public string Supplier { get; set; }

        public double? DifferentPercent { get; set; }

        public long? CreatedTimeStamp { get; set; }
        public bool Updated { get; set; }



    }
}