using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class Preference
    {
        public int Id { get; set; }
        public bool KOTGenerate { get; set; }
        public bool EnforceCustomerNo { get; set; }
        public bool QuickOrder { get; set; }
        public bool FreeQuantity { get; set; }
        public bool ShowUpcategory { get; set; }
        public bool ShowTaxonBill { get; set; }
        public bool AdminOnlyCancel { get; set; }
        public bool DineIn { get; set; }
        public bool TakeAway { get; set; }
        public bool AdvanceOrder { get; set; }
        public bool OnlineOrder { get; set; }
        public bool Delivery { get; set; }
        public bool Updated { get; set; }
        public int PriceType { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
