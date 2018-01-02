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
        void AddCustomer(Customers customers);
        void DeleteCustomer(Customers customers);
        void EditCustomer(Customers customers);
        IQueryable<Customers> GetAllCustomers();
        Customers GetCustomerById(string id);
    }
}
