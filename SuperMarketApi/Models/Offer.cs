using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public bool Updated { get; set; }
        [Column(TypeName = "Date")]
        public DateTime EffectiveDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime ExpiryDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdateDateTime { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
