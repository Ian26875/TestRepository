using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebNorthWind.Respositories
{
    public interface IGenerRespository<T> where T:class,new()
    {
        IEnumerable<T> GetAll();
        T FirstOrDefault(Func<T, bool> func);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
