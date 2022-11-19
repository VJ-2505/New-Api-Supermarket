using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class CategoryVariant
    {
        public int Id { get; set; }
        public bool Updated { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Variant")]
        public int VariantId { get; set; }
        public virtual Variant Variant { get; set; }

        [ForeignKey("VariantGroup")]
        public int VariantGroupId { get; set; }
        public virtual VariantGroup VariantGroup { get; set; }


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
