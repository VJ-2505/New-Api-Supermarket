using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class Operator
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int OperType { get; set; }
        public bool Updated { get; set; }
    }
}
