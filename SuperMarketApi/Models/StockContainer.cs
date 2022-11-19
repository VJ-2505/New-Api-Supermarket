using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System;

namespace SuperMarketApi.Models
{
    [Serializable]
    public class StockContainer
    {
        [Key]
        public int StockContainerId { get; set; }

        [ForeignKey("Store")]
        [Display(Name = "Store ")]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }

        //[Display(Name = "Product ")]
        //public int ProductId { get; set; }
        public string StockContainerName { get; set; }
        public double ContainerWight { get; set; }
        //public bool IsDefault { get; set; }
        [Display(Name = "Status")]
        public bool IsActive { get; set; }
        [Display(Name = "Status")]
        public string StatusText
        {
            get
            {
                if (IsActive == true) return "Active";
                else return "Not in Use";
            }
        }
        //[NotMapped]
        //[Display(Name = "Product Name")]
        //public string ProductName { get; set; }
        [NotMapped]
        [Display(Name = "Store Name")]
        public string StoreName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? CreatedDate { get; set; }

        [ForeignKey("User")]
        public int? CreatedBy { get; set; }
        public virtual Contact User { get; set; }

        public bool IsCompanyLevel { get; set; }


        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}