using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.Azure.KeyVault.Models;

namespace SuperMarketApi.Models
{
    [Serializable]
    public class StockBatch
    {
        public int StockBatchId { get; set; }
        public bool Updated { get; set; }

        [ForeignKey("Stock")]
        public int StockId { get; set; }
        public virtual Stock Stock { get; set; }

        [ForeignKey("Batch")]
        public int? BatchId { get; set; }
        public virtual Batch Batch { get; set; }
          

        public double Quantity { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? CreatedDate { get; set; }

        [ForeignKey("User")]
        public int? CreatedBy { get; set; }
        public virtual User User { get; set; }


        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set;}

        [NotMapped]
        public string ProductName { get; set; }






    }
}
