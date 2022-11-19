using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class Wastage
    {
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Store")]
        public int? StoreId { get; set; }//------------------
        public virtual Store Store { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "Date")]
        public DateTime WastageDate { get; set; }//------------------


    }
}
