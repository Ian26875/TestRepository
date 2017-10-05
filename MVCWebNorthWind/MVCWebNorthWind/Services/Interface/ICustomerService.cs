using MVCWebNorthWind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebNorthWind.Services.Interface
{
    public interface ICustomerService
    {
        IEnumerable<Customers> GetCustomersByCondition(string companyName,string contactName);
        Customers AddCustomer(Customers customers);
        Customers DeleteCustomer(Customers customers);
        Customers EditCustomer(Customers customers);
        Customers GetAllCustomers();
    }
}
