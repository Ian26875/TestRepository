using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;
using CommonClassLibrary.Extensions;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    [TestFixture]
    public class DataTableExtensionTestClass
    {
        public class Test
        {
            public string StringColumn { get; set; }
            public int IntColumn { get; set; }
            public decimal DecimalColumn { get; set; }
            public long LongColumn { get; set; }
            public double DoubleColumn { get; set; }
        }

        private DataTable dataTableTest;

        [SetUp]     
        public void DataTableTestInit()
        {
            dataTableTest = new DataTable();
            dataTableTest.Columns.Add("StringColumn", typeof(string));
            dataTableTest.Columns.Add("IntColumn", typeof(int));
            dataTableTest.Columns.Add("DecimalColumn", typeof(decimal));
            dataTableTest.Columns.Add("LongColumn", typeof(long));
            dataTableTest.Columns.Add("DoubleColumn", typeof(double));
            DataRow dataRow = dataTableTest.NewRow();
            dataRow.SetField("StringColumn", "TESTString");
            dataRow.SetField("IntColumn", 100);
            dataRow.SetField("DecimalColumn", 147852);
            dataRow.SetField("LongColumn", 123456789);
            dataRow.SetField("DoubleColumn", 0.123);
            dataTableTest.Rows.Add(dataRow);
        }


        [Test]
        [Category("DataTableExtension")]
        [TestCaseSource("DataTableInit")]
        public void ToList_將DataTable轉型成List強型別物件_內容資料必須完全相同()
        {
            //arrange

            var test = new Test
            {
                StringColumn="",
                IntColumn= 100,
                DecimalColumn= 147852,
                LongColumn= 123456789,
                DoubleColumn= 0.123
            };
            List<Test> expected = new List<Test>() { test };
            //act
            var actual = dataTableTest.ToList<Test>();
            
            //assert
            Assert.That(actual, Is.EquivalentTo(expected));
        }

       
    }
}
