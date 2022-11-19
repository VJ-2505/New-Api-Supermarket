using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public bool Updated { get; set; }
        [ForeignKey("User")]
        public int DeliveryBoyId { get; set; }
        public virtual User DeliveryBoy { get; set; }

        public int OrderId { get; set; }

        public string Location { get; set; }

        public int StatusId { get; set; }

    }
}
