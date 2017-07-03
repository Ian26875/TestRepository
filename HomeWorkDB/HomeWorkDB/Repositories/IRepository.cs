using System;
using System.Linq;
using System.Linq.Expressions;

namespace HomeWorkDB.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        bool Any(Expression<Func<T, bool>> expression);
        void Delete(T entity);
        T FirstOrDefault();
        T FirstOrDefault(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        T Insert(T entity);
        T SingleOrDefault();
        T SingleOrDefault(Expression<Func<T, bool>> expression);
        void Update(T entity);
    }
}