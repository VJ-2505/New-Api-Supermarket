using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketApi.Models
{
    public class StorePaymentType
    {
       
            public int Id { get; set; }
            public string Name { get; set; }
            public string MachineId { get; set; }
            public bool IsActive { get; set; }

            [DataType(DataType.Date)]
            public DateTime CreatedDateTime { get; set; }//------------------

            [DataType(DataType.Date)]
            public DateTime ModifiedDateTime { get; set; }//------------------

            [ForeignKey("Store")]
            public int StoreId { get; set; }
            public virtual Store Store { get; set; }

            [ForeignKey("Company")]
            public int CompanyId { get; set; }//------------------
            public virtual Company Company { get; set; }

            public bool Hidden { get; set; }
        
    }
}
