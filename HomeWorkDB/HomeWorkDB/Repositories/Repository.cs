using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HomeWorkDB.Repositories
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class, new()
    {
        private IUnitOfWork _UnitOfWork;
        private bool disposed = false;

        public Repository(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }
        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _UnitOfWork.db.Set<T>().Any(expression);
        }
        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return _UnitOfWork.db.Set<T>().FirstOrDefault(expression);
        }
        public T FirstOrDefault()
        {
            return _UnitOfWork.db.Set<T>().FirstOrDefault();
        }
        public T SingleOrDefault(Expression<Func<T, bool>> expression)
        {
            return _UnitOfWork.db.Set<T>().SingleOrDefault(expression);
        }
        public T SingleOrDefault()
        {
            return _UnitOfWork.db.Set<T>().SingleOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return _UnitOfWork.db.Set<T>();
        }       
        public T Insert(T entity)
        {
            return _UnitOfWork.db.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _UnitOfWork.db.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            _UnitOfWork.db.Set<T>().Remove(entity);
        }

        public void Dispose()
        {
            Disposing(true);
            GC.SuppressFinalize(this);
        }
        protected void Disposing(bool isDispose)
        {
            if (disposed==false)
            {
                if (isDispose)
                {
                    _UnitOfWork.Dispose();
                }
            }
            disposed = true;
        }
    }
}