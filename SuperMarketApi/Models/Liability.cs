using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class Liability
    {
        public int Id { get; set; }

        public int? Count { get; set; }

        public string Description { get; set; }

        [ForeignKey("LiabilityType")]
        public int LiabilityTypeId { get; set; }
        public virtual LiabilityType LiabilityType { get; set; }

        [ForeignKey("Contact")]
        public int? ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        [ForeignKey("Vendor")]
        public int? VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime? CreatedDate { get; set; }

        [ForeignKey("User")]
        public int? CreatedBy { get; set; }
        public virtual Contact User { get; set; }

        public bool IsActive { get; set; }

        public bool? IsOnlinePayment { get; set; }
      

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
