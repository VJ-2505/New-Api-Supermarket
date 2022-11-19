using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace SuperMarketApi.Models
{
    public class Vendor
    {
        [ForeignKey("Contact")]
        public int Id { get; set; }
        public virtual Contact Contact { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int? PostalCode { get; set; }
        public string Password { get; set; }
        public string OTP { get; set; }
        public int? RemainingPoints { get; set; }
        public bool Updated { get; set; }

        [Column(TypeName = "Date")]
        public DateTime LastRedeemDate { get; set; }

        public int? TotalPoints { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [ForeignKey("Store")]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }
        ////////////////////////////////////afsdvsd/////////////////////////////////
        //[ForeignKey("Contact")]
        //public int VendorId { get; set; }
        //public virtual Contact Contact { get; set; }

        [Display(Name = "Business Name")]
        [Required]
        [StringLength(50)]
        //[Index(IsUnique = true)]
        public string BusinessName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? CreatedDate { get; set; }

        [ForeignKey("User")]
        public int? CreatedBy { get; set; }
        public virtual Contact User { get; set; }

        public int? CreditPeriod { get; set; }

        public bool IsPlanned { get; set; }

        [ForeignKey("PaymentStore")]
        public int? PaymentStoreId { get; set; }
        public virtual Store PaymentStore { get; set; }

        public int DelivPeriod { get; set; }
        public int DelivTimeHrs { get; set; }
        [NotMapped]
        public string PaymentStoreName { get; set; }

    }
}
