using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class OrderStatus
    {
        public long accepted { get; set; }
        public long foodready { get; set; }
        public long dispatched { get; set; }
        public long delivered { get; set; }
    }
}
