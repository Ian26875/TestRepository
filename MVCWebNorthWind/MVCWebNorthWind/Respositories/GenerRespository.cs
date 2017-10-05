using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCWebNorthWind.Respositories
{
    public class GenerRespository<T> : IGenerRespository<T> where T : class, new()
    {
        private IUnitOfWork _UnitOfWork;
        public GenerRespository(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }


        public void Delete(T entity)
        {
            _UnitOfWork.Context.Set<T>().Remove(entity);
        }

        public T FirstOrDefault(Func<T, bool> func)
        {
            return _UnitOfWork.Context.Set<T>().FirstOrDefault(func);
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            _UnitOfWork.Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _UnitOfWork.Context.Entry(entity).State = EntityState.Modified;            
        }
    }
}