using MVCWebNorthWind.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCWebNorthWind.Models;
using MVCWebNorthWind.Respositories;

namespace MVCWebNorthWind.Services
{
    public class CustomerService : ICustomerService
    {
        public IGenerRespository<Customers> CustomerRespository { get ; private set; }

        public CustomerService(IGenerRespository<Customers> generRespository)
        {
            CustomerRespository = generRespository;
        }

       
        public void AddCustomer(Customers customers)
        {
            CustomerRespository.Insert(customers);
        }

        public void DeleteCustomer(Customers customers)
        {
            throw new NotImplementedException();
        }

        public void EditCustomer(Customers customers)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customers> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customers> GetCustomersByCondition(string companyName, string contactName)
        {
            throw new NotImplementedException();
        }
    }
}