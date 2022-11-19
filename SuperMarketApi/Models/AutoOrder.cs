using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SuperMarketApi.Models
{
    [Serializable]
    public class AutoOrder
    {
        public int AutoOrderId { get; set; }

        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }
        public virtual Contact Supplier { get; set; }

        [ForeignKey("OrderStore")]
        public int OrderStoreId { get; set; }
        public virtual Store OrderStore { get; set; }

        //[ForeignKey("FrequencyType")]
        //public int? FrequencyTypeId { get; set; }
        //public virtual FrequencyType FrequencyType { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? CreatedDate { get; set; }

        [ForeignKey("User")]
        public int? CreatedBy { get; set; }
        public virtual Contact User { get; set; }

        public bool? IsIgnorePendOrd { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

    }
}
