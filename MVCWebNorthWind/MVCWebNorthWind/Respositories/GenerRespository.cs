using MVCWebNorthWind.Respositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCWebNorthWind.Respositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="MVCWebNorthWind.Respositories.Interface.IGenerRespository{T}" />
    public class GenerRespository<T> : IGenerRespository<T> where T : class, new()
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private IUnitOfWork _UnitOfWork;
        /// <summary>
        /// Initializes a new instance of the <see cref="GenerRespository{T}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public GenerRespository(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }


        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(T entity)
        {
            _UnitOfWork.Context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Firsts the or default.
        /// </summary>
        /// <param name="func">The function.</param>
        /// <returns></returns>
        public T FirstOrDefault(Func<T, bool> func)
        {
            return _UnitOfWork.Context.Set<T>().FirstOrDefault(func);
        }

        /// <summary>
        /// Singles the or default.
        /// </summary>
        /// <param name="func">The function.</param>
        /// <returns></returns>
        public T SingleOrDefault(Func<T, bool> func)
        {
            return _UnitOfWork.Context.Set<T>().SingleOrDefault(func);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return _UnitOfWork.Context.Set<T>();
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public T Insert(T entity)
        {
            return _UnitOfWork.Context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(T entity)
        {
            _UnitOfWork.Context.Entry(entity).State = EntityState.Modified;            
        }
    }
}