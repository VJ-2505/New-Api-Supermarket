using SuperMarketApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class ProductOptionGroup
    {
        public int Id { get; set; }
        public bool Updated { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("OptionGroup")]
        public int OptionGroupId { get; set; }
        public virtual OptionGroup OptionGroup { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        //public int MinimumSelectable { get; set; }
        //public int MaximumSelectable { get; set; }

        [NotMapped]
        public IQueryable ProductOptions { get; set; }
    }
}
