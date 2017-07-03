using System.Data.Entity;

namespace HomeWorkDB.Repositories
{
    public interface IUnitOfWork
    {
        DbContext db { get; set; }
        void Dispose();
        int SaveChanges();
    }
}