using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCWebNorthWind.Common;

namespace MVCWebNorthWind.Tests.Common
{
    [TestClass]
    public class FinancialHelperUnitTest
    {

        [TestMethod]
        [Owner("Ian")]
        [TestCategory("FinancialHelper")]
        [TestProperty("FinancialHelper", "GetPaymentInformation")]
        public void GetPaymentInformation_使用者輸入_預期結果運算結果()
        {
            //arrange
            var instance =new FinancialHelper();
            //var expected = expected;
            ////act
            //var actual = actual;
            ////assert
            //Assert.AreEqual(expected, actual);
        }
    }
}
