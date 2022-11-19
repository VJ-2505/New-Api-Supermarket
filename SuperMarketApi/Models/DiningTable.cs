using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarketApi.Models
{
    public class DiningTable
    {
        public int Id { get; set; }
        public string Description { get; set; }

        [ForeignKey("DiningArea")]
        public int DiningAreaId { get; set; }
        public virtual DiningArea DiningArea { get; set; }

        public int TableStatusId { get; set; }

        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }
    }
}
