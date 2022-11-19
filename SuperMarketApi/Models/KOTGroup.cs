using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class KOTGroup
    {
        public int Id { get; set; }
        public bool Updated { get; set; }
        public string Description { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        //[ForeignKey("Store")]
        //public int StoreId { get; set; }
        //public virtual Store Store { get; set; }
        public string Printer { get; set; }

        public bool IsEditable { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }
    }
}
