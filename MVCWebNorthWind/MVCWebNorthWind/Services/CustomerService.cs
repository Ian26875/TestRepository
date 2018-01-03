using MVCWebNorthWind.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCWebNorthWind.Models;
using MVCWebNorthWind.Respositories;
using LinqKit;
using Common.Extensions;
using MVCWebNorthWind.Respositories.Interface;

namespace MVCWebNorthWind.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MVCWebNorthWind.Services.Interface.ICustomerService" />
    public class CustomerService : ICustomerService
    {
        /// <summary>
        /// The customer respository
        /// </summary>
        private IGenerRespository<Customers> _customerRespository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        /// <param name="generRespository">The gener respository.</param>
        public CustomerService(IGenerRespository<Customers> generRespository)
        {
            _customerRespository = generRespository;
        }

        /// <summary>
        /// Adds the customer.
        /// </summary>
        /// <param name="customers">The customers.</param>
        /// <exception cref="ArgumentNullException">customers</exception>
        public void AddCustomer(Customers customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }
            _customerRespository.Insert(customers);
        }

        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <param name="customers">The customers.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void DeleteCustomer(Customers customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException();
            }
            _customerRespository.Delete(customers);
        }

        /// <summary>
        /// Edits the customer.
        /// </summary>
        /// <param name="customers">The customers.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void EditCustomer(Customers customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException();
            }
            _customerRespository.Update(customers);
        }

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Customers> GetAllCustomers()
        {
            return _customerRespository.GetAll();
        }

        /// <summary>
        /// Gets the customers by condition.
        /// </summary>
        /// <param name="companyName">Name of the company.</param>
        /// <param name="contactName">Name of the contact.</param>
        /// <returns></returns>
        public IEnumerable<Customers> GetCustomersByCondition(string companyName, string contactName)
        {

            var predicate = PredicateBuilder.New<Customers>(defaultExpression: false);

            predicate = predicate.Or(c => c.CompanyName == companyName);

            predicate = predicate.Or(c => c.ContactName == contactName);

            var source = _customerRespository.GetAll();

            var searchResult = source.Where(predicate);

            return searchResult;
        }

        /// <summary>
        /// Gets the customer by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">id</exception>
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