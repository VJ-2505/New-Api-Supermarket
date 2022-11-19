using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class OrdItemOptions
    {
        public int Id { get; set; }
        public bool Updated { get; set; }
        [ForeignKey("OrderItem")]
        public int OrderItemId { get; set; }
        public virtual OrderItem OrderItem { get; set; }

        public string orderitemrefid { get; set; }

        public double Price { get; set; }

        [ForeignKey("Option")]
        public int OptionId { get; set; }
        public virtual Option Option { get; set; }

    }
}
