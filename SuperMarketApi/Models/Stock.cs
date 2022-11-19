using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.Azure.KeyVault.Models;

namespace SuperMarketApi.Models
{
    [Serializable]
    public class Stock
    {
        public int StockId { get; set; }
        public bool Updated { get; set; }
        //public double Quantity { get; set; }

        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? CreatedDate { get; set; }

        [ForeignKey("User")]
        public int? CreatedBy { get; set; }
        public virtual User User { get; set; }

        //[ForeignKey("SupplyStore")]
        //public int? SupplyStoreId { get; set; }
        //public virtual Store SupplyStore { get; set; }

        // [ForeignKey("Vendor")]
        // public int? VendorId { get; set; }
        // public virtual Vendor Vendor { get; set; }

        // [ForeignKey("Frequency")]
        // public int? FrequencyTypeId { get; set; }
        // public virtual FrequencyType Frequency { get; set; }

        [ForeignKey("ProdStore")]
        public int? ProdStoreId { get; set; }
        public virtual Store ProdStore { get; set; }

        //[NotMapped]
        //public string ProdStoreName { get; set; }

        //[ForeignKey("PkgStore")]
        //public int? PkgStoreId { get; set; }
        //public virtual Store PkgStore { get; set; }

        //[NotMapped]
        //public string PkgStoreName { get; set; }

        [ForeignKey("StorageStore")]
        public int? StorageStoreId { get; set; }
        public virtual Store StorageStore { get; set; }

        //[ForeignKey("DefaultContainer")]
        //public int? DefaultContainerId { get; set; }
        //public virtual StockContainer DefaultContainer { get; set; }

        [NotMapped]
        public string StorageStoreName { get; set; }

        // public double? AvgConsumption { get; set; }
        // public double? CritLevel { get; set; }
        // public double? LowLevel { get; set; }
        // public double? HighLevel { get; set; }
        // public double? TooHighLevel { get; set; }
        // public double? OrderLevel { get; set; }
        // public double? MinOrdQty { get; set; }
        // public double? MinOrdBlock { get; set; }
        // public double? ContainerCount { get; set; }
        // public double? Factor { get; set; }

        // [ForeignKey("StockType")]
        // public string StockTypeCode { get; set; }
        //// public virtual EnumVal StockType { get; set; }

        // public bool UsageCheck { get; set; }

        // public bool IgnoreCurStock { get; set; }

        public bool IsAutoProduction { get; set; }
        public bool IsDispatchProduction { get; set; }
        public bool IsPOSImportProduction { get; set; }
        public bool IsStockUpdProduction { get; set; }
        public int? SortOrder { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [ForeignKey("Barcode")]
        public int BarcodeId { get; set; }
        public virtual Barcode Barcode { get; set; }

        //public double? Price { get; set; }
        //public double? NewPrice { get; set; }
        //public double? Tax1 { get; set; }
        //public double? NewTax1 { get; set; }
        //public double? Tax2 { get; set; }
        //public double? NewTax2 { get; set; }
        //public double? Tax3 { get; set; }
        //public double? NewTax3 { get; set; }

        // [ForeignKey("NewVendor")]
        // public int? NewVendorId { get; set; }
        //  public virtual Vendor NewVendor { get; set; }

        //  [ForeignKey("Vendor1")]
        //  public int? VendorId1 { get; set; }
        //  public virtual Vendor Vendor1 { get; set; }

        //  [ForeignKey("Vendor2")]
        //  public int? VendorId2 { get; set; }
        ////  public virtual Vendor Vendor2 { get; set; }
        //  [ForeignKey("Vendor3")]
        //  public int? VendorId3 { get; set; }
        //  //public virtual Vendor Vendor3 { get; set; }
        //  public bool? IsReviewed { get; set; }
        //  public bool? IsPriceChanged { get; set; }
        //  public bool? IsTaxChanged { get; set; }
        //  public bool? IsVendorChanged { get; set; }

        //  [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //  public System.DateTime? UpdatedDateTime { get; set; }
        //  //public bool IsNegProd { get; set; }

        //  [ForeignKey("Bill")]
        //  public int? BillId { get; set; }
        // // public virtual Bill Bill { get; set; }
    }
}
