using MVCWebNorthWind.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCWebNorthWind.Models;
using MVCWebNorthWind.Respositories;
using LinqKit;
using Common.Extensions;

namespace MVCWebNorthWind.Services
{
    public class CustomerService : ICustomerService
    {
        private IGenerRespository<Customers> _customerRespository;

        public CustomerService(IGenerRespository<Customers> generRespository)
        {
            _customerRespository = generRespository;
        }

        public void AddCustomer(Customers customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }
            _customerRespository.Insert(customers);
        }

        public void DeleteCustomer(Customers customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException();
            }
            _customerRespository.Delete(customers);
        }

        public void EditCustomer(Customers customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException();
            }
            _customerRespository.Update(customers);
        }

        public IQueryable<Customers> GetAllCustomers()
        {
            return _customerRespository.GetAll();
        }

        public IEnumerable<Customers> GetCustomersByCondition(string companyName, string contactName)
        {

            var predicate = PredicateBuilder.New<Customers>(defaultExpression: false);

            predicate = predicate.Or(c => c.CompanyName == companyName);

            predicate = predicate.Or(c => c.ContactName == contactName);

            var source = _customerRespository.GetAll();

            var searchResult = source.Where(predicate);

            return searchResult;
        }

        public Customers GetCustomerById(string id)
        {
            if (id.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(id));
            }
            var customers= _customerRespository.FirstOrDefault(x => x.CustomerID == id);
            return customers;
        }
    }
}