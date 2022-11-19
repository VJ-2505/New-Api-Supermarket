using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("ParentStore")]
        public int? ParentStoreId { get; set; }
        public virtual Store ParentStore { get; set; }

        public bool IsSalesStore { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string GSTno { get; set; }
        public string receiptprinter { get; set; }
        public bool isactive { get; set; }
        public int FoodPrepTime { get; set; }
        public int AutoAcceptTime { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan OpeningTime { get; set; }

        //[DataType(DataType.Time)]
        //public TimeSpan FoodPrepTime { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan ClosingTime { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public string kotprinter { get; set; }
        public bool Updated { get; set; }

        [ForeignKey("Plan")]
        public int? PlanId { get; set; }//------------------
        public virtual Plan Plan { get; set; }
    }
}
