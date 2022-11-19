using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class UPTax
    {
        public string code { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool active { get; set; }
        public JObject structure { get; set; }
        public List<string> item_ref_ids { get; set; }
        public bool Updated { get; set; }
    }
}
