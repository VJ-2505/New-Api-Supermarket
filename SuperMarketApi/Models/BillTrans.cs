using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace SuperMarketApi.Models
{
    public class BillTrans
    {
        public BillTrans()
        {

        }
        public BillTrans(int transId, int billId)
        {
            BillTransId = transId;
            BillId = billId;
        }
        [ForeignKey("Transaction")]
        public int BillTransId { get; set; }
        public virtual Transaction Transaction { get; set; }

        [ForeignKey("Bill")]
        public int BillId { get; set; }
        public virtual Bill Bill { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
