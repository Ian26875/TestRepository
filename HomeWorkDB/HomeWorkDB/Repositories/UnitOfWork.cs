using HomeWorkDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeWorkDB.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
       
        public UnitOfWork()
        {
            db = new SkillTreeHomeworkEntities();
        }
        public UnitOfWork(DbContext dbContext)
        {
            db = dbContext;
        }
        public DbContext db { get; set; }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}