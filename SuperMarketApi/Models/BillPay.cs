using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class BillPay
    {
        public BillPay()
        {

        }
        public BillPay(int billId, int? transId, double amt)
        {
            BillId = billId;
            TransactionId = transId;
            Amount = amt;
        }
        public int Id { get; set; }

        [ForeignKey("Bill")]
        public int BillId { get; set; }
        public virtual Bill Bill { get; set; }

        [ForeignKey("Transaction")]
        public int? TransactionId { get; set; }
        public virtual Transaction Transaction { get; set; }

        //[ForeignKey("CreditMapping")]
        //public int? CreditMappingId { get; set; }
        //public virtual CreditMapping CreditMapping { get; set; }

        public double Amount { get; set; }

        [NotMapped]
        public double PendAmountEdit
        {
            get { return Bill.PendAmount + Amount; }
        }

        [NotMapped]
        public double PaidAmountEdit
        {
            get { return Bill.PaidAmount - Amount; }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? CreatedDate { get; set; }

        [ForeignKey("User")]
        public int? CreatedBy { get; set; }
        public virtual Contact User { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

    }
}
