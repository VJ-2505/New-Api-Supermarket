using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class CategoryAddon
    {
        public int Id { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public bool Updated { get; set; }
        [ForeignKey("Addon")]
        public int AddonId { get; set; }
        public virtual Addon Addon { get; set; }

        [ForeignKey("AddonGroup")]
        public int AddonGroupId { get; set; }
        public virtual AddonGroup AddonGroup { get; set; }


        public double Price { get; set; }
        public double? TakeawayPrice { get; set; }
        public double? DeliveryPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }


    }
}
