using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class AdditionalCharges
    {
        public int Id { get; set; }
        public string Description { get; set; }        
        public int ChargeType { get; set; }        
        public double ChargeValue { get; set; }
        public bool Updated { get; set; }
        [ForeignKey("TaxGroup")]
        public int TaxGroupId { get; set; }
        public virtual TaxGroup TaxGroup { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

      
    }
}
