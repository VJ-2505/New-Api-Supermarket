using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class MaintBillType
    {
        //[Key]
        public int Id { get; set; }

        //[Required(ErrorMessage = "Required")]
        //[Display(Name = "Description")]
        public string Description { get; set; }

        [ForeignKey("LiabilityType")]
        public int LiabilityTypeId { get; set; }
        public virtual LiabilityType LiabilityType { get; set; }
        [DataType(DataType.Date)]

        public System.DateTime? CreatedDate { get; set; }
        [ForeignKey("User")]
        public int? CreatedBy { get; set; }
        public virtual Contact User { get; set; }

        public bool IsActive { get; set; }
        public bool IsVerify { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

    }
}
