using System;

namespace SuperMarketApi.Controllers
{
    internal class EnableCorsAttribute : Attribute
    {
        private string v;
        private string v1;
        private string v2;

        public EnableCorsAttribute(string v)
        {
            this.v = v;
        }

        public EnableCorsAttribute(string v, string v1, string v2) : this(v)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}