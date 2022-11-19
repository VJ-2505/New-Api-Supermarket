using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarketApi.Models
{
    public class MasterCatalogue
    {
        public List<UPCategory> categories { get; set; }
        public bool flush_items { get; set; }
        public List<UPItem> items { get; set; }
        public bool flush_option_groups { get; set; }
        public List<UPOptionGroup> option_groups { get; set; }
        public bool flush_options { get; set; }
        public List<UPOption> options { get; set; }
        public List<UPTax> taxes { get; set; }
    }
}
