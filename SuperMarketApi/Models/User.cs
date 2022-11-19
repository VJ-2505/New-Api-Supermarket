using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pin { get; set; }
        public bool Updated { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [ForeignKey("Accounts")]
        public int AccountId { get; set; }
        public virtual Accounts Accounts { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        [NotMapped]
        public List<int> mapped_stores { get; set; }

        [NotMapped]
        public List<string> mapped_stores_name { get; set; }

    }
}
