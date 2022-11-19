using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? FreeQtyPercentage { get; set; }
        public int? MinimumQty { get; set; }
        public bool IsUPCategory { get; set; }
        public bool IsSynced { get; set; }
        public bool isactive { get; set; }
        public int? SortOrder { get; set; }
        public bool Updated { get; set; }
        [ForeignKey("ParentCategory")]
        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }

        [NotMapped]
        public List<int> variantgroupids { get; set; }
    }
}
