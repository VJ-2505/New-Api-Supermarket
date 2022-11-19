using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class ProductOption
    {
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public bool Updated { get; set; }

        [ForeignKey("Option")]
        public int OptionId { get; set; }
        public virtual Option Option { get; set; }

        public double Price { get; set; }
        public double? TakeawayPrice { get; set; }
        public double? DeliveryPrice { get; set; }
        public double? UPPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }

        //[ForeignKey("MappedProduct")]
        ////public int? MappedProductId { get; set; }
        //public virtual Product MappedProduct { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
