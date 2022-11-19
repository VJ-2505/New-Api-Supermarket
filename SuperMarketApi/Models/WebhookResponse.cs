using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class WebhookResponse
    {
        public int Id { get; set; }
        public string RefId { get; set; }
        public int StatusCode { get; set; }
        public string message { get; set; }
        public bool Updated { get; set; }
    }
}
