using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SuperMarketApi.Models.Enum;


namespace SuperMarketApi.Models
{
    [Serializable]
    public class AccountType
    {       
        [Key]
        public string AccountTypeCd { get; set; }
        public string Description{ get; set; }


    }
}

