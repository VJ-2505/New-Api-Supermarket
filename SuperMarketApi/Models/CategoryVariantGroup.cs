using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarketApi.Models
{
    public class CategoryVariantGroup
    {
        public int Id { get; set; }

        [ForeignKey("Company")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public bool Updated { get; set; }
        [ForeignKey("VariantGroup")]
        public int VariantGroupId { get; set; }
        public virtual VariantGroup VariantGroup { get; set; }

        [NotMapped]
        public string VariantGroupName { get; set; }
        public List<Variant> Variants { get; set; }
    }
}
