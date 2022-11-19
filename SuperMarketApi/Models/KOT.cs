using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class KOT
    {
        public int Id { get; set; }
        public int KOTStatusId { get; set; }
        public string Instruction { get; set; }
        public string KOTNo { get; set; }

        public string refid { get; set; }
        public bool Updated { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

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

        [ForeignKey("KOTGroup")]
        public int? KOTGroupId { get; set; }
        public virtual KOTGroup KOTGroup { get; set; }

        [NotMapped]
        public string OrderItems { get; set; }
    }
}