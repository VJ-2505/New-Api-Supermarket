﻿using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class OrderLog
    {
        public int Id { get; set; }
        public string Payload { get; set; }
        public string Error { get; set; }
        //public bool Updated { get; set; }
        [DataType(DataType.Date)]
        public DateTime LoggedDateTime { get; set; }//------------------

        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }//------------------
        public virtual Company Company { get; set; }
    }
}
