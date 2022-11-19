using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class PlanDetail
    {
        public int Id { get; set; }       

        [ForeignKey("Plan")]
        public int PlanId { get; set; }
        public virtual Plan Plan { get; set; }
        public string Key { get; set; }
        public bool IsActive { get; set; }
    }
}
