using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Exceptions;

namespace MVCWebNorthWind.Tests.NSubstitute
{
    [TestClass]
    public class NSbustitute
    {

        [TestMethod]
        [Owner("Ian")]
        public void Add_輸入參數1及2_預期結果為3()
        {
            //arrange
            //建立Mock物件
            ICalculator calculator = Substitute.For<ICalculator>();
            //指定方法並指定回傳值
            calculator.Add(1, 2).Returns(3);
            int expected = 3;
            //act
            int actual = calculator.Add(1, 2);
            //assert
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod]
        public void Test_GetStarted_ReceivedSpecificCall()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2);
            //檢查是否有接收的指定調用
            calculator.Received().Add(1, 2);
            calculator.DidNotReceive().Add(5, 7);
        }

        [TestMethod]
        [ExpectedException(typeof(ReceivedCallsException))]
        public void Test_GetStarted_DidNotReceivedSpecificCall()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Add(5, 7);

            calculator.Received().Add(1, 2);
        }

        [TestMethod]
        public void Test_GetStarted_MatchArguments()
        {
            ICalculator calculator = Substitute.For<ICalculator>();

            calculator.Add(10, -5);

            calculator.Received().Add(10, Arg.Any<int>());
            calculator.Received().Add(10, Arg.Is<int>(x => x < 0));
        }
    }
}
