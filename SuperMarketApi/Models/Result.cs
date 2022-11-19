using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class Result
    {
        public int Id { get; set; }
        public bool Updated { get; set; }
        [ForeignKey("VariableType")]
        public int VariableTypeId { get; set; }
        public virtual VariableType VariableType { get; set; }

        [ForeignKey("OfferType")]
        public int OfferTypeId { get; set; }
        public virtual OfferType OfferType { get; set; }

        public double value { get; set; }

        [ForeignKey("Operator")]
        public int OperatorId { get; set; }
        public virtual Operator Operator { get; set; }

        public int OperatorValue { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
