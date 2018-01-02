using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCWebNorthWind.Models;
using MVCWebNorthWind.Respositories.Interface;
using MVCWebNorthWind.Services;
using MVCWebNorthWind.Services.Interface;
using NSubstitute;
using FluentAssertions;
using Ploeh.AutoFixture;

namespace MVCWebNorthWind.Tests.Services
{
    [TestClass]
    public class OrderServiceTests
    {
        private IGenerRespository<Orders> _ordersRepository;

        /// <summary>
        /// Tests the initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _ordersRepository = Substitute.For<IGenerRespository<Orders>>();
        }

        /// <summary>
        /// Gets the system under test.
        /// </summary>
        /// <returns></returns>
        private IOrderService GetSystemUnderTest()
        {
            IOrderService sut = new OrderService(this._ordersRepository);
            return sut;
        }

        [TestMethod]
        [Owner("Ian")]
        [TestCategory("OrderService")]
        [TestProperty("OrderService", "CreateOrder")]
        public void CreateOrder_Orders輸入null_應ThrowArgumentNullException()
        {
            //arrange
            var sut = this.GetSystemUnderTest();
            Orders order = null;
            //act
            Action action=()=>sut.CreateOrder(order);
            //assert
            action.ShouldThrow<ArgumentNullException>();
        }
    }
}
