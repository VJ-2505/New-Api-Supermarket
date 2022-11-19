using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class OrderCharges
    {
        public int Id { get; set; }
        public bool Updated { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey("AdditionalCharges")]
        public int AdditionalChargeId { get; set; }
        public virtual AdditionalCharges AdditionalCharges { get; set; }

        public double ChargePercentage { get; set; }
        public double ChargeAmount { get; set; }
        public double Tax1 { get; set; }
        public double Tax2 { get; set; }
        public double Tax3 { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [ForeignKey("Store")]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }
    }
}
