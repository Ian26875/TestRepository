using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClassLibrary.Extensions
{
    /// <summary>
    /// Class DataTableExtensions.
    /// </summary>
    public static class DataTableExtensions
    {
        /// <summary>
        /// To the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable">The data table.</param>
        /// <returns>List&lt;T&gt;.</returns>
        public static List<T> ToList<T>(this DataTable dataTable) where T:class,new()
        {
            List<T> items = new List<T>();
           
            return items;
        }
    }
}
