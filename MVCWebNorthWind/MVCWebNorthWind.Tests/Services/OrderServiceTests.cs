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
        private IGenerRespository<Orders> _customerRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _customerRepository = Substitute.For<IGenerRespository<Orders>>();
        }


        private IOrderService GetSystemUnderTest()
        {
            IOrderService sut = new OrderService(this._customerRepository);
            return sut;
        }

    }
}
