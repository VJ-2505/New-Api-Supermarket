using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class DiscountRule
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public int DiscountType { get; set; }
        public double DiscountValue { get; set; }
        public double MiniOrderValue { get; set; }
        public double MaxDiscountAmount { get; set; }
        public bool Updated { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        //[ForeignKey("Store")]
        //public int StoreId { get; set; }
        //public virtual Store Store { get; set; }
    }
}
