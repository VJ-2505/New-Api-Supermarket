using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace SuperMarketApi.Models
{
    public static class DbContextExtensions
    {
        public static IQueryable<Object> Query(this DbContext _context, Type t)
        {
            return (IQueryable<Object>)_context.GetType().GetMethod("Set").MakeGenericMethod(t).Invoke(_context, null);
        }

        public static IQueryable<Object> Query(this DbContext _context, String table)
        {
            Type TableType = _context.GetType().Assembly.GetExportedTypes().FirstOrDefault(t => t.Name == table);
            IQueryable<Object> ObjectContext = _context.Query(TableType);
            return ObjectContext;
        }
        public static IQueryable<Object> GetById(this DbContext _context, String table,int id)
        {
            Type TableType = _context.GetType().Assembly.GetExportedTypes().FirstOrDefault(t => t.Name == table);
            IQueryable<Object> ObjectContext = _context.Query(TableType);
            return ObjectContext;
        }

        public static DbSet<Object> Set(this DbContext _context, Type t)
        {
            return (DbSet<Object>)_context.GetType().GetMethod("Set").MakeGenericMethod(t).Invoke(_context, null);
        }


        public static DbSet<Object> Set(this DbContext _context, String table)
        {
            Type TableType = _context.GetType().Assembly.GetExportedTypes().FirstOrDefault(t => t.Name == table);
            DbSet<Object> ObjectContext = _context.Set(TableType);
            return ObjectContext;
        }
    }
}
