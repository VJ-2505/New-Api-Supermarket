using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class Aggregator
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Updated { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        public int Commission { get; set; }
    }
}
