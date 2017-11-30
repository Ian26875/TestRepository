using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonClassLibrary.Extensions
{
    /// <summary>
    /// Class DataTableExtensions.
    /// </summary>
    public static class DataTableExtensions
    {
        private static readonly IDictionary<Type, ICollection<PropertyInfo>> propertiesDictionary =
      new Dictionary<Type, ICollection<PropertyInfo>>();
        /// <summary>
        /// To the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable">The data table.</param>
        /// <returns>List&lt;T&gt;.</returns>
        public static List<T> ToList<T>(this DataTable dataTable) where T : class, new()
        {
            try
            {
                if (dataTable.Columns.Count == 0)
                {
                    return null;
                }
                Type objType = typeof(T);
                ICollection<PropertyInfo> properties;

                lock (propertiesDictionary)
                {
                    if (!propertiesDictionary.TryGetValue(objType, out properties))
                    {
                        properties = objType.GetProperties().Where(property => property.CanWrite).ToArray();
                        propertiesDictionary.Add(objType, properties);
                    }
                }

                List<T> list = new List<T>();

                foreach (DataRow row in dataTable.AsEnumerable())
                {
                    T obj = new T();

                    foreach (PropertyInfo prop in properties)
                    {
                        Type propType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                        Object safeValue = row[prop.Name] == DBNull.Value ? null : Convert.ChangeType(row[prop.Name], propType);

                        prop.SetValue(obj, safeValue, null);

                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return default(List<T>);
            }
        }
    }
}
