using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class PurchaseList
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public string ProductName { get; set; }
        public int ProductQty { get; set; }
        public int ProductPrice { get; set; }
        public int ProductTax { get; set; }
        public int BillAmount { get; set; }
        public int PaidAmount { get; set; }
        public string VendorName { get; set; }
        public string VendorNumber { get; set; }
        public string VendorAddress { get; set; }

        [Column(TypeName = "Date")]
        public DateTime ReceviedDate { get; set; }

        [ForeignKey("Store")]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public string Delivery { get; set; }
        public string Warranty { get; set; }

        [ForeignKey("Unit")]
        public int? UnitId { get; set; }
        public virtual Unit Unit { get; set; }



    }
}
