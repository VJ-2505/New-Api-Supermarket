using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class StoreProductAddon
    {
        public int Id { get; set; }
        public bool Updated { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        [ForeignKey("AddOn")]
        public int AddOnId { get; set; }
        public virtual Addon AddOn { get; set; }

        public double Price { get; set; }
        public double TakeawayPrice { get; set; }
        public double DeliveryPrice { get; set; }
        public bool IsAvailable  { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public int ProductAddonId { get; set; }
    }
}
