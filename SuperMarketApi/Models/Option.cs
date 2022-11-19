using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public double Price { get; set; }
        public double TakeawayPrice { get; set; }
        public double DeliveryPrice { get; set; }
        public double UPPrice { get; set; }
        public bool IsSynced { get; set; }
        public bool Updated { get; set; }

        [ForeignKey("OptionGroup")]
        public int OptionGroupId { get; set; }
        public virtual OptionGroup OptionGroup { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }

        [NotMapped]
        public int ProductId { get; set; }
    }
}
