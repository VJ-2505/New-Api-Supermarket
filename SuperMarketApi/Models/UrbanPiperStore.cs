using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class UrbanPiperStore
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string UPId { get; set; }
        public bool Updated { get; set; }
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        public bool Zomato { get; set; }
        public bool IsZomato { get; set; }
        public bool Swiggy { get; set; }
        public bool IsSwiggy { get; set; }
        public bool UberEats { get; set; }
        public bool FoodPanda { get; set; }
        public bool IsUrbanPiper { get; set; }
        public bool UrbanPiper { get; set; }
        public bool Dunzo { get; set; }
        public bool IsDunzo { get; set; }
        public bool Amazon { get; set; }
        public bool IsAmazon { get; set; }

        [ForeignKey("BrandId")]
        public int? BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan FoodPrepTime { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

    }
}
