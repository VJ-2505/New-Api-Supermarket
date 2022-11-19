 using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Updated { get; set; }

        [ForeignKey("Unit")]
        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public double Price { get; set; }
        public double TakeawayPrice { get; set; }
        public double DeliveryPrice { get; set; }
        public double UPPrice { get; set; }
        public string ImgUrl { get; set; }
        public string ProductCode { get; set; }
        public string BarCode { get; set; }
        public bool isactive { get; set; }
        public int? SortOrder { get; set; }
        public bool Recomended { get; set; }
        public bool IsStockMaintained { get; set; }
        public int? minquantity { get; set; }
        public int? minblock { get; set; }
        public string brand { get; set; }

        [ForeignKey("TaxGroup")]
        public int TaxGroupId { get; set; }
        public virtual TaxGroup TaxGroup { get; set; }

        [ForeignKey("KOTGroup")]
        public int? KOTGroupId { get; set; }
        public virtual KOTGroup KOTGroup { get; set; }
        public Byte[] Image { get; set; }

        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }
        public double Factor { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        //[ForeignKey("Variant")]
        //public int VarientId { get; set; }
        //public virtual Variant Variant { get; set; }

    }
}