using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class ShiftSummary
    {
        public int Id { get; set; }
        public double OpeningBalance { get; set; }
        public double ClosingBalance { get; set; }
        public bool Updated { get; set; }
        [DataType(DataType.Date)]
        public DateTime ShiftStartTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime ShiftEndTime { get; set; }

        [Column(TypeName = "Date")]
        public DateTime SalesDate { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
