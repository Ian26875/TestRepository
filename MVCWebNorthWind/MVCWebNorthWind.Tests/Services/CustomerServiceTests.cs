using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCWebNorthWind.Models;
using MVCWebNorthWind.Respositories;
using MVCWebNorthWind.Services;
using MVCWebNorthWind.Services.Interface;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Ploeh.AutoFixture;
using System.IO;
using CsvHelper;
using MVCWebNorthWind.Respositories.Interface;

namespace MVCWebNorthWind.Services.Tests.Services
{
    [TestClass()]
    [DeploymentItem(@"CsvTestData\Customer_Data.csv")]
    public class CustomerServiceTests
    {
        private IGenerRespository<Customers> _customerRepository;

        /// <summary>
        /// Tests the initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _customerRepository = Substitute.For<IGenerRespository<Customers>>();
        }

        /// <summary>
        /// 取得目前測試類別
        /// </summary>
        /// <returns></returns>
        private ICustomerService GetSystemUnderTest()
        {
            var sut = new CustomerService(this._customerRepository);
            return sut;
        }

        /// <summary>
        /// Gets the data source from CSV.
        /// </summary>
        /// <returns></returns>
        private static List<Customers> GetDataSourceFromCsv()
        {
            var models = new List<Customers>();
            using (var sr = new StreamReader(@"Customer_Data.csv"))
            using (var reader = new CsvReader(sr))
            {
                var records = reader.GetRecords<Customers>();
                models.AddRange(records);
            }
            return models;
        }


        [TestMethod]
        [Owner("Ian")]
        [TestCategory("CustomerService")]
        [TestProperty("CustomerService", "AddCustomer")]
        public void AddCustomer_Customer為null_應ThrowArgumentNullException()
        {
            //arrange
            var sut = GetSystemUnderTest();
            Customers customer = null;
            //act
            Action action = () => sut.AddCustomer(customer);
            //assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [Owner("Ian")]
        [TestCategory("CustomerService")]
        [TestProperty("CustomerService", "DeleteCustomer")]
        public void DeleteCustomer_Customer為null_應ThrowArgumentNullException()
        {
            //arrange
            var sut = GetSystemUnderTest();
            Customers customer = null;
            //act
            Action action = () => sut.DeleteCustomer(customer);
            //assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [Owner("Ian")]
        [TestCategory("CustomerService")]
        [TestProperty("CustomerService", "EditCustomer")]
        public void EditCustomer_Customer為null_應ThrowArgumentNullException()
        {
            //arrange
            var sut = GetSystemUnderTest();
            Customers customer = null;
            //act
            Action action = () => sut.EditCustomer(customer);
            //assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [Owner("Ian")]
        [TestCategory("CustomerService")]
        [TestProperty("CustomerService", "GetAllCustomers")]
        public void GetAllCustomers_應取得所有筆數10筆()
        {
            //arrange
            var sut = GetSystemUnderTest();
            Fixture fixture = new Fixture();
            var expected = 10;

            var source = fixture.Build<Customers>()
                 .OmitAutoProperties()
                 .CreateMany(count: 10).AsQueryable();
            _customerRepository.GetAll().ReturnsForAnyArgs(source);
            //act
            var actual = sut.GetAllCustomers();
            //assert
            actual.Any().Should().BeTrue();
            actual.Should().HaveCount(expected);
        }

        [TestMethod]
        [Owner("Ian")]
        [TestCategory("CustomerService")]
        [TestProperty("CustomerService", "GetAllCustomers")]
        public void GetAllCustomers_應取得所有筆數91筆()
        {
            //arrange
            var sut = GetSystemUnderTest();

            var source = GetDataSourceFromCsv().AsQueryable();

            _customerRepository.GetAll().ReturnsForAnyArgs(source);

            var expected = 91;
            //act
            var actual = sut.GetAllCustomers();

            //assert
            actual.Any().Should().BeTrue();

            actual.Should().HaveCount(expected);
        }

        [TestMethod]
        [Owner("Ian")]
        [TestCategory("CustomerService")]
        [TestProperty("CustomerService", "GetAllCustomers")]
        public void GetAllCustomers_company為空字串_contactName為空字串_應取得零筆()
        {
            //arrange   
            var sut = GetSystemUnderTest();

            var company = "";

            var contactName = "";

            var expected = 0;

            var source = GetDataSourceFromCsv().AsQueryable();

            _customerRepository.GetAll().ReturnsForAnyArgs(source);

            //act
            var actual = sut.GetCustomersByCondition(company, contactName);

            //assert
            actual.Should().NotContainNulls();

            actual.Should().HaveCount(expected);
        }


        [TestMethod]
        [Owner("Ian")]
        [TestCategory("CustomerService")]
        [TestProperty("CustomerService", "GetAllCustomers")]
        public void GetAllCustomers_company為Bottom_DollarMarkets_contactName為空字串_應取得公司為Bottom_Dollar_Markets()
        {
            //arrange
            var sut = GetSystemUnderTest();

            var company = "Bottom-Dollar Markets";

            var contactName = "";

            var source = GetDataSourceFromCsv().AsQueryable();

            var expected = source.Where(x => x.CompanyName == "Bottom-Dollar Markets");

            _customerRepository.GetAll().ReturnsForAnyArgs(source);

            //act
            var actual = sut.GetCustomersByCondition(company, contactName);

            //assert
            actual.Should().NotContainNulls();

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        [Owner("Ian")]
        [TestCategory("CustomerService")]
        [TestProperty("CustomerService", "GetAllCustomers")]
        public void GetAllCustomers_company為空字串_contactName為Hanna_Moos_應取得ContractName為Hanna_Moos()
        {
            //arrange
            var sut = GetSystemUnderTest();

            var company = "";

            var contactName = "Hanna Moos";

            var source = GetDataSourceFromCsv().AsQueryable();

            var expected = source.Where(x => x.ContactName == "Hanna Moos");

            _customerRepository.GetAll().ReturnsForAnyArgs(source);

            //act
            var actual = sut.GetCustomersByCondition(company, contactName);

            //assert
            actual.Should().NotContainNulls();

            actual.ShouldBeEquivalentTo(expected);
        }


        [TestMethod]
        [Owner("Ian")]
        [TestCategory("CustomerService")]
        [TestProperty("CustomerService", "GetCustomerById")]
        public void GetCustomerById_id為ANATR_應取得customerId為ANATR()
        {
            //arrange
            var sut = GetSystemUnderTest();

            var id = "ANATR";


            var source = GetDataSourceFromCsv();

            var expected = source.Single(x => x.CustomerID == "ANATR");

            _customerRepository.FirstOrDefault(x => x.CustomerID == id).
                ReturnsForAnyArgs(expected);

            //act
            var actual = sut.GetCustomerById(id);

            //assert
            actual.Should().Be(expected);

        }

        [TestMethod]
        [Owner("Ian")]
        [TestCategory("CustomerService")]
        [TestProperty("CustomerService", "GetCustomerById")]
        public void GetCustomerById_id為null_應ThrowArgumentNullException()
        {
            //arrange
            var sut = GetSystemUnderTest();
            var id = "";
            //act
            Action action = () => sut.GetCustomerById(id);
            //assert
            action.ShouldThrow<ArgumentNullException>();
        }

    }
}