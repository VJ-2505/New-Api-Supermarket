using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using SuperMarketApi.Models.Enum;
using System.Linq;
using System;
using SuperMarketApi.Models;

namespace SuperMarketApi.Models
{
    [Serializable]
    public class Bill
    {
        public int BillId { get; set; }

        public string InVoiceNum { get; set; }
        public int BillType { get; set; }
        public int? DispatchType { get; set; }
        public double BillAmount { get; set; }
        public double BillAmountNoTax { get; set; }
        public double TaxAmount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? DueDate { get; set; }

        public double PaidAmount { get; set; }

        public Double? Quantity { get; set; }

        [ForeignKey("Provider")]
        public int ProviderId { get; set; }
        public virtual Contact Provider { get; set; }

        [ForeignKey("Receiver")]
        public int ReceiverId { get; set; }
        public virtual Contact Receiver { get; set; }

        [ForeignKey("DispatchBy")]
        public int? DispatchById { get; set; }
        public virtual Contact DispatchBy { get; set; }

        [ForeignKey("ReceivedBy")]
        public int? ReceivedById { get; set; }
        public virtual Contact ReceivedBy { get; set; }

        //[ForeignKey("Vehicle")]
        //public int? VehicleId { get; set; }
        //public virtual Liability Vehicle { get; set; }

        [ForeignKey("PaymentStore")]
        public int? PaymentStoreId { get; set; }
        public virtual Contact PaymentStore { get; set; }

        //[ForeignKey("MaintBillType")]
        //public int? MaintBillTypeId { get; set; }
        //public virtual MaintBillTypes MaintBillType { get; set; }

        //[ForeignKey("Liability")]
        //public int? LiabilityId { get; set; }
        //public virtual Liability Liability { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime? RecurDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? CreatedDate { get; set; }

        [ForeignKey("User")]
        public int? CreatedBy { get; set; }
        public virtual Contact User { get; set; }

        [Column(TypeName = "Date")]
        public System.DateTime? BillDate { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime? DispatchedDate { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime? ReceivedDate { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime? ReturnedDate { get; set; }

        public int? ReceiveStatus { get; set; }

        public bool ReceiveLater { get; set; }

        public bool DispatchLater { get; set; }

        public byte[] SoftCopy { get; set; }

        [NotMapped]
        public string ReceiveLaterDesc
        {
            get
            {
                if (ReceiveLater == true)
                    return "Yes";
                else
                    return "No";
            }

        }

        [NotMapped]
        public string DispatchLaterDesc
        {
            get
            {
                if (DispatchLater == true)
                    return "Yes";
                else
                    return "No";
            }

        }



        public bool IsReturn { get; set; }

        //[NotMapped]
        //public string StatusDesc
        //{
        //    get
        //    {
        //        if (ReceiveStatus != null)
        //            return System.Enum.GetName(typeof(BillReceiveStatus), ReceiveStatus);
        //        else
        //            return null;

        //    }
        //}

        //[NotMapped]
        //public string DispTypeDesc
        //{
        //    get
        //    {
        //        if (DispatchType != null)
        //            return System.Enum.GetName(typeof(DispatchTypeEnum), DispatchType);
        //        else
        //            return null;
        //    }

        //}

        [NotMapped]
        public double PendAmount
        {
            get { return BillAmount - PaidAmount; }
        }

        [NotMapped]
        public double PendReturnAmount
        {
            get { return PaidAmount - BillAmount; }
        }

        //[NotMapped]
        //public double TotalReturnAmount
        //{
        //    get
        //    {
        //        ApplicationDbContext db = new ApplicationDbContext(System.Web.HttpContext.Current.Session["CustomerDb"].ToString());
        //        var ordProdDetail = db.OrdProdDetails.Where(op => op.BillId == BillId && op.OrdProdType == (int)OrderProductType.Return);
        //        if (ordProdDetail.Count() == 0)
        //            return 0;
        //        else
        //            return ordProdDetail.Sum(op => ((op.Amount == null ? 0 : (double)op.Amount) + (op.TaxAmount == null ? 0 : (double)op.TaxAmount)));
        //    }
        //}

        [NotMapped]
        public virtual List<OrderItem> OrderItems { get; set; }

        [NotMapped]
        public virtual List<OrderItemDetail> OrderItemDetails { get; set; }

        public int StoreId
        {
            get
            {
                if (BillType == (int)BillTypeEnum.Credit) return ProviderId;
                else return ReceiverId;
            }
        }

        public int ContactId
        {
            get
            {
                if (BillType == (int)BillTypeEnum.Credit) return ReceiverId;
                else return ProviderId;
            }
        }

        public Contact Store
        {
            get
            {
                if (BillType == (int)BillTypeEnum.Credit) return Provider;
                else return Receiver;
            }
        }

        public Contact Contact
        {
            get
            {
                if (BillType == (int)BillTypeEnum.Credit) return Receiver;
                else return Provider;
            }
        }

        public Bill()
        {
            PaidAmount = 0;
        }
        public Bill(int provId, int recvId)
        {
            ProviderId = provId;
            ReceiverId = recvId;
        }
        public double DiscPercent { get; set; }
        public double DiscAmount { get; set; }
        public double TotalDiscount { get; set; }

        //[NotMapped]
        //public virtual List<BillPay> BillPays { get; set; }

        [NotMapped]
        public string BillNo { get; set; }

        [NotMapped]
        [DataType(DataType.Time)]
        public string DispatchDateStr { get; set; }

        [NotMapped]
        [DataType(DataType.Time)]
        public string DispatchTime { get; set; }

        [NotMapped]
        [DataType(DataType.Date)]
        public string DeliverDateStr
        {
            get;
            set;
        }

        [NotMapped]
        [DataType(DataType.Date)]
        public string DueDateStr
        {
            get;
            set;
        }

        [NotMapped]
        [DataType(DataType.Time)]
        public string DeliverTime
        {
            get;
            set;
        }

        [NotMapped]
        [DataType(DataType.Time)]
        public string ReceivedDateStr { get; set; }

        [NotMapped]
        [DataType(DataType.Time)]
        public string ReceivedTime { get; set; }

        [NotMapped]
        [DataType(DataType.Time)]
        public string ReturnedDateStr { get; set; }

        [NotMapped]
        [DataType(DataType.Time)]
        public string ReturnedTime { get; set; }

        [NotMapped]
        public bool ShowDiscount { get; set; }
        [NotMapped]
        public bool ShowRelatedOdr { get; set; }
        [NotMapped]
        public bool ShowProdReturn { get; set; }
        [NotMapped]
        public bool ShowBatch { get; set; }
        public bool? IsPaid { get; set; }


        [ForeignKey("CreditType")]
        public string CreditTypeStr { get; set; }
        public virtual EnumVal CreditType { get; set; }

        [ForeignKey("ResponsibleBy")]
        public int? ResponsibleById { get; set; }
        public virtual Contact ResponsibleBy { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public bool? ShowAllProd { get; set; }

        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }

    }

}

