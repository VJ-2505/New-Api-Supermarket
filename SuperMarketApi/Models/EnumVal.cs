using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace SuperMarketApi.Models
{
    [Serializable]
    public class EnumVal
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
