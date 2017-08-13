using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Repositories
{
    public interface IRepository<TEntity> where TEntity:class,new()
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllByKey(Func<TEntity,bool> fun);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
