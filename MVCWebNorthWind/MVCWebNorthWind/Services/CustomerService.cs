using MVCWebNorthWind.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCWebNorthWind.Models;
using MVCWebNorthWind.Respositories;
using LinqKit;

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
            if (customers == null)
            {
                throw new ArgumentNullException();
            }
            CustomerRespository.Insert(customers);
        }

        public void DeleteCustomer(Customers customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException();
            }
            CustomerRespository.Delete(customers);
        }

        public void EditCustomer(Customers customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException();
            }
            CustomerRespository.Update(customers);
        }

        public IQueryable<Customers> GetAllCustomers()
        {
            return CustomerRespository.GetAll();
        }

        public IEnumerable<Customers> GetCustomersByCondition(string companyName, string contactName)
        {
            var predicate = PredicateBuilder.New<Customers>(defaultExpression:false);

            predicate = predicate.Or(c => c.ContactName.Contains(contactName));

            predicate = predicate.Or(c => c.CompanyName.Contains(companyName));

            var searchResult= CustomerRespository.GetAll().Where(predicate);

            return searchResult;
        }
    }
}