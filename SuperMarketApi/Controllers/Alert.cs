using System;

namespace SuperMarketApi.Controllers
{
    internal class Alert
    {
        public Alert()
        {
        }

        public DateTime AlertDateTime { get; internal set; }
        public string AlertName { get; internal set; }
        public string Note { get; internal set; }
        public int StoreId { get; internal set; }
        public int CompanyId { get; internal set; }
    }
}