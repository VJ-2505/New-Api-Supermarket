using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
using Microsoft.Azure.KeyVault.Models;

namespace SuperMarketApi.Models
{
    [Serializable]
    public class Batch
    {
        public int BatchId { get; set; }

        public int BatchNo { get; set; }
        public bool Updated { get; set; }

        public double Quantity { get; set; }

        [ForeignKey("Barcode")]
        public int BarcodeId { get; set; }
        public virtual Barcode Barcode { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        //[ForeignKey("BarcodeVariant")]
        //public int BarcodeVariantId { get; set; }
        //public virtual BarcodeVariant BarcodeVariant { get; set; }

        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? ExpiaryDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EntryDateTime { get; set; }//------------------

        public double Price { get; set; }
    }
}
