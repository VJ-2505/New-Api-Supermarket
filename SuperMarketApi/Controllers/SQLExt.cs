using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Transactions;

namespace SuperMarketApi.Controllers
{
    public static class SQLExt
    {

        public static TransactionScope CreateTransScope()
        {
            var options = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.DefaultTimeout
            };

            return new TransactionScope(TransactionScopeOption.Required, options);
        }
    }
}
