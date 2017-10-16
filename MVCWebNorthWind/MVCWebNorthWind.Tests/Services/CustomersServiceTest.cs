using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCWebNorthWind.Models;
using MVCWebNorthWind.Respositories;
using MVCWebNorthWind.Services;
using MVCWebNorthWind.Services.Interface;
using MVCWebNorthWind.Tests.Mocket;
using System.Linq;
using NSubstitute;
using System.Collections.Generic;

namespace MVCWebNorthWind.Tests.Services
{
    /// <summary>
    /// Class CustomersServiceTest.
    /// </summary>
    [TestClass]
    public class CustomersServiceTest
    {


        [TestMethod]
        public void GetCustomersByCondition_使用者均不輸入_資料筆數為零()
        {
            //arrange        
            IGenerRespository<Customers> generRespository = new MocketCustomersRespository();
            ICustomerService service = new CustomerService(generRespository);
            string companyName = "";
            string contactName = "";
            var expected = 0;
            //act
            var customers = service.GetCustomersByCondition(companyName, contactName);
            var actual = customers.ToList().Count;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Owner("Ian")]
        [TestCategory("CustomerService")]
        [TestProperty("CustomerService", "GetCustomersByCondition")]
        public void GetCustomersByCondition_輸入公司名稱為AlfredsFutterkiste_抓取資料筆數一筆()
        {
            //arrange        
            IGenerRespository<Customers> generRespository = new MocketCustomersRespository();
            ICustomerService service = new CustomerService(generRespository);
            string companyName = "Alfreds Futterkiste";
            string contactName = "";
            var expected = 0;
            //act
            service.GetCustomersByCondition(companyName, contactName);
            var actual = 0;
            //assert
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        [Owner("Ian")]
        public void 測試方法_測試情境_預期結果()
        {
            //arrange        
            IGenerRespository<Customers> generRespository = Substitute.For<IGenerRespository<Customers>>();
          
            ICustomerService service = new CustomerService(generRespository);
            string companyName = "";
            string contactName = "";
            var expected = 0;
            //act
            var customers = service.GetCustomersByCondition(companyName, contactName);
            var actual = customers.ToList().Count;
            //assert
            Assert.AreEqual(expected, actual);
        }

    }
}
