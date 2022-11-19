using SuperMarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace SuperMarketApi.Models
{
    public class TransMode
    {
        public int Id { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? CreatedDate { get; set; }

        [ForeignKey("User")]
        public int? CreatedBy { get; set; }
        public virtual Contact User { get; set; }

        public bool IsIn { get; set; }
        public bool IsOut { get; set; }
        public bool IsStoreTrx { get; set; }


    }
}
