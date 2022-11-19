using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class Printer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string IPAddress { get; set; }
        public int PortNumber { get; set; }
        public int NoOfCharacters { get; set; }
        public bool Updated { get; set; }

    }
}
