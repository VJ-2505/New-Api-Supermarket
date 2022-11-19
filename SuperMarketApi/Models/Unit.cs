using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Description { get; set; }

        //[ForeignKey("Company")]
        //public int? CompanyId { get; set; }
        //public virtual Company Company { get; set; }

        public bool Updated { get; set; }

    }
}
