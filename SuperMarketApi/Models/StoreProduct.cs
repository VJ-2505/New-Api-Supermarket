using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class StoreProduct
    {
        public int Id { get; set; }
        public bool Updated { get; set; }
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public double Price { get; set; }
        public double UPPrice { get; set; }
        public double TakeawayPrice { get; set; }
        public double DeliveryPrice { get; set; }
        public bool IsDineInService { get; set; }
        public bool IsTakeAwayService { get; set; }
        public bool IsDeliveryService { get; set; }
        public bool IsActive { get; set; }
        public bool UPenabled { get; set; }
        public bool Available { get; set; }
        public bool IsSynced { get; set; }
        public int UPAction { get; set; }
        public int? SortOrder { get; set; }
        public bool Recommended { get; set; }

        [DataType(DataType.Date)]
        public DateTime SyncedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

    }
}