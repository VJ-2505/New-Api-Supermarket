using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class UPItem
    {
        public int ref_id { get; set; }
        public string title { get; set; }
        public bool available { get; set; }
        public int? sort_order { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int current_stock { get; set; }
        public bool recommended { get; set; }
        public bool sold_at_store { get; set; }
        public int food_type { get; set; }
        public string img_url { get; set; }
        public List<string> category_ref_ids { get; set; }
        public JObject tags { get; set; }
        //public List<string> included_platforms { get; set; }
        public List<JObject> translations { get; set; }
        public bool Updated { get; set; }
    }
}