using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RestaurentName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNo { get; set; }
        public string Provider{ get; set; }
        public bool Updated { get; set; }
    }
}
