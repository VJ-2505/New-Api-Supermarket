using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class OfferRule
    {
        public int Id { get; set; }
        public bool Updated { get; set; }
        [ForeignKey("Offer")]
        public int OfferId { get; set; }
        public virtual Offer Offer { get; set; }

        public int RuleId { get; set; }
        public int Type { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
