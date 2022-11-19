using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class Condition
    {
        public int Id { get; set; }
        public bool Updated { get; set; }
        [ForeignKey("VariableType")]
        public int VariableTypeId { get; set; }
        public virtual VariableType VariableType { get; set; }

        [ForeignKey("ParentCondition")]
        public int ParentConditionId { get; set; }
        public virtual Condition ParentCondition { get; set; }

        public int ValueId { get; set; }

        [ForeignKey("Operator")]
        public int OperatorId { get; set; }
        public virtual Operator Operator { get; set; }

        [ForeignKey("Operator")]
        public int JoinOperatorId { get; set; }
        public virtual Operator JoinOperator { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
