using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class PlannedTrans
    {
        public int Id { get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        [ForeignKey("Store")]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public int? BillId { get; set; }
        public string InVoiceNum { get; set; }
        [Column(TypeName = "Date")]
        public System.DateTime? BillDate { get; set; }

        public double Amount { get; set; }

        public string Comments { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? PlannedDateTime { get; set; }

        [Column(TypeName = "Date")]
        public System.DateTime? PlannedDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? ClosedDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? CreatedDate { get; set; }

        [ForeignKey("User")]
        public int? CreatedBy { get; set; }
        public virtual Contact User { get; set; }

        [ForeignKey("Status")]
        public string StatusCode { get; set; }
        public virtual EnumVal Status { get; set; }

        [NotMapped]
        [DataType(DataType.Date)]
        public string PlannedDateStr { get; set; }

        [NotMapped]
        [DataType(DataType.Date)]
        public string ClosedDateStr { get; set; }

        [NotMapped]
        public string BillDateStr { get; set; }

        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

    }
}
