using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SuperMarketApi.Models.Enum;

namespace SuperMarketApi.Models
{
    public class Cheque
    {
        public Cheque()
        {

        }
        public Cheque(string chqNo,
           double amt, System.DateTime chqDate, int transId)
        {
            if (chqDate == new System.DateTime(0))
            {
                chqDate = System.DateTime.Now;
            }
            ChequeNo = chqNo;
            Amount = amt;
            ChequeDate = chqDate;
            IssuedTrxId = transId;
            Status = (int)ChequeStatusEnum.Pending;
        }
        public int Id { get; set; }
        public string ChequeNo { get; set; }
        public double Amount { get; set; }
        [ForeignKey("IssuedTrx")]
        public int IssuedTrxId { get; set; }
        public virtual Transaction IssuedTrx { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime ChequeDate { get; set; }

        [ForeignKey("ClearedTrx")]
        public int? ClearedTrxId { get; set; }
        public virtual Transaction ClearedTrx { get; set; }

        public int Status { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime? CreatedDate { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
