using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class KOTGroupPrinter
    {
        public int Id { get; set; }
        public string Printer { get; set; }
        public bool Updated { get; set; }
        [ForeignKey("KOTGroup")]
        public int KOTGroupId { get; set; }
        public virtual KOTGroup KOTGroup { get; set; }

        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

    }
}
