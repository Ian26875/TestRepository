using MVCWebNorthWind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebNorthWind.Tests
{
    public class CustomerComparer:Customers
    {
        public override bool Equals(object obj)
        {
            if (obj is Customers)
            {
                string[] field = { "CustomerID", "CompanyName", "ContactName", "ContactTitle",
                    "Address", "City", "Region",  "PostalCode", "Country", "Phone",  "Fax"};
                Customers expected = this as Customers;
                Customers actual = obj as Customers;
                var properies = typeof(Customers).GetProperties().Where(x=> field.Contains(x.Name));
                foreach (var pro in properies)
                {
                    bool comparer = pro.GetValue(expected).Equals(pro.GetValue(actual));
                    if (comparer == false)
                    {
                        return false;
                    }
                }
            }
            return base.Equals(obj);
        }
    }
}
