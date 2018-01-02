using MVCWebNorthWind.Models;
using MVCWebNorthWind.Respositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCWebNorthWind.Respositories
{
    public class UnitOfWork : IUnitOfWork
    {       
        public UnitOfWork(DbContext dbContext)
        {
            Context = dbContext;
        }

        public DbContext Context { get; set; }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}