using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class LiabilityType
    {

        public int Id { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime? CreatedDate { get; set; }

        [ForeignKey("User")]
        public int? CreatedBy { get; set; }
        public virtual Contact User { get; set; }

        public bool IsVehicle { get; set; }
        public bool IsOnlinePayment { get; set; }


        public bool IsActive { get; set; }
     
        public bool IsSpecial { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
