using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class UPOptionGroup
    {
        public int Id { get; set; }
        public string ref_id { get; set; }
        public string title { get; set; }
        public int min_selectable { get; set; }
        public int max_selectable { get; set; }
        public bool active { get; set; }
        //public List<string> item_ref_ids { get; set; }
        public bool Updated { get; set; }
    }
}
