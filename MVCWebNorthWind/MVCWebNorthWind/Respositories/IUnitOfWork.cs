using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebNorthWind.Respositories
{
    public interface IUnitOfWork
    {
        DbContext Context { get; set; }
        int SaveChanges();
    }
}
