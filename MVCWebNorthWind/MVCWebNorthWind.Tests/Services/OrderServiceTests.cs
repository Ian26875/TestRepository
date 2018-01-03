using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCWebNorthWind.Models;
using MVCWebNorthWind.Respositories.Interface;
using MVCWebNorthWind.Services;
using MVCWebNorthWind.Services.Interface;
using NSubstitute;
using FluentAssertions;
using Ploeh.AutoFixture;
using MVCWebNorthWind.DTOs;
using AutoMapper;
using MVCWebNorthWind.Mappings;

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
            Mapper.Reset();
            Mapper.Initialize
            (
                cfg =>
                {
                    cfg.AddProfile<ServiceMappingProfile>();
                }
            );
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
        public void CreateOrder_OrderDTO輸入null_應ThrowArgumentNullException()
        {
            //arrange
            var sut = this.GetSystemUnderTest();
            OrderDTO order = null;
            //act
            Action action = () => sut.CreateOrder(order);
            //assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [Owner("Ian")]
        [TestCategory("OrderService")]
        [TestProperty("OrderService", "CreateOrder")]
        public void CreateOrder_新增訂單Order_應取得OrderId為100()
        {
            //arrange
            var sut = this.GetSystemUnderTest();
            
            var expected = 100;

            Fixture fixture = new Fixture();
            OrderDTO intput = fixture.Build<OrderDTO>()
                .Without(x => x.OrderID)
                .Create();

            Orders source = fixture.Build<Orders>()
                .OmitAutoProperties()
                .With(x => x.OrderID, 100)
                .Create();

            this._ordersRepository.Insert(null)
                .ReturnsForAnyArgs(source);

            //act
            var actual = sut.CreateOrder(intput);

            //assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        [Owner("Ian")]
        [TestCategory("OrderService")]
        [TestProperty("OrderService", "DeleteOrder")]
        public void DeleteOrder_輸入OrderDTO為null_應ThrowArgumentNullException()
        {
            //arrange
            var sut = this.GetSystemUnderTest();
            OrderDTO input = null;
            //act
            Action action = () => sut.DeleteOrder(input);
            //assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [Owner("Ian")]
        [TestCategory("OrderService")]
        [TestProperty("OrderService", "DeleteOrder")]
        public void DeleteOrder_輸入OrderDTO為OrderId為null_應ThrowArgumentNullException()
        {
            //arrange
            var sut = this.GetSystemUnderTest();
            Fixture fixture = new Fixture();
            OrderDTO input = fixture.Build<OrderDTO>()
                .Without(x => x.OrderID)
                .Create();
            //act
            Action action = () => sut.DeleteOrder(input);
            //assert
            action.ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        [Owner("Ian")]
        [TestCategory("OrderService")]
        [TestProperty("OrderService", "DeleteOrder")]
        public void DeleteOrder_輸入OrderDTO為產品資訊_應正常執行不拋例外處理()
        {
            //arrange
            var sut = this.GetSystemUnderTest();
            var fixture = new Fixture();
            var input = fixture.Create<OrderDTO>();          
            //act
            Action action = () => sut.DeleteOrder(input);
            //assert
            action.ShouldNotThrow();
        }

        [TestMethod]
        [Owner("Ian")]
        [TestCategory("OrderService")]
        [TestProperty("OrderService", "EditOrder")]
        public void EditOrder_輸入OrderDTO為null_應ThrowArgumentNullException()
        {
            //arrange
            var sut = this.GetSystemUnderTest();
            OrderDTO input = null;
            //act
            Action action = () => sut.EditOrder(input);
            //assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [Owner("Ian")]
        [TestCategory("OrderService")]
        [TestProperty("OrderService", "EditOrder")]
        public void EditOrder_輸入OrderDTO為OrderId為null_應ThrowArgumentNullException()
        {
            //arrange
            var sut = this.GetSystemUnderTest();
            Fixture fixture = new Fixture();
            OrderDTO input = fixture.Build<OrderDTO>()
                .Without(x => x.OrderID)
                .Create();
            //act
            Action action = () => sut.EditOrder(input);
            //assert
            action.ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        [Owner("Ian")]
        [TestCategory("OrderService")]
        [TestProperty("OrderService", "EditOrder")]
        public void EditOrder_輸入OrderDTO為產品資訊_應正常執行不拋例外處理()
        {
            //arrange
            var sut = this.GetSystemUnderTest();
            var fixture = new Fixture();
            var input = fixture.Build<OrderDTO>().Create();      
            //act
            Action action = () => sut.EditOrder(input);
            //assert
            action.ShouldNotThrow();
        }

        [TestMethod]
        [Owner("Ian")]
        [TestCategory("OrderService")]
        [TestProperty("OrderService", "GetAll")]
        public void GetAll_應取得所有Orders()
        {
            //arrange
            var expected = 10;

            var sut = this.GetSystemUnderTest();

            var fixture = new Fixture();
            var source = fixture.Build<Orders>()
                .OmitAutoProperties()
                .CreateMany(count:10)
                .AsQueryable();

            this._ordersRepository.GetAll().Returns(source);

            //act
            var actual= sut.GetAllOrders();

            //assert
            actual.Any().Should().BeTrue();
            actual.Should().HaveCount(expected);
        }


    }
}
