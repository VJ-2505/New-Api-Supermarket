using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarketApi.Models
{
    public class BarcodeVariant
    {
        public int Id { get; set; }
        public bool Updated { get; set; }
        [ForeignKey("Company")]
        public int BarcodeId { get; set; }
        public virtual Barcode Barcode { get; set; }

        [ForeignKey("Variant")]
        public int VariantId { get; set; }
        public virtual Variant Variant { get; set; }
    }
}
