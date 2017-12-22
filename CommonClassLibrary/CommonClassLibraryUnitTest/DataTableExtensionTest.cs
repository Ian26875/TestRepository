using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using CommonClassLibrary.Extensions;

namespace CommonClassLibraryUnitTest
{
    [TestClass]
    public class DataTableExtensionTest
    {
        private DataTable dataTableTest { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            dataTableTest = new DataTable();
            dataTableTest.Columns.Add("StringColumn", typeof(string));
            dataTableTest.Columns.Add("IntColumn", typeof(int));
            dataTableTest.Columns.Add("DecimalColumn", typeof(decimal));
            dataTableTest.Columns.Add("LongColumn", typeof(long));
            dataTableTest.Columns.Add("DoubleColumn", typeof(double));
        }

        [TestMethod]
        [TestCategory("DataTableExtension")]
        [TestProperty("DataTableExtension", "ToList")]
        public void ToList_將Columns為空DataTable轉型成List強型別物件_回傳空物件()
        {
            //arrange       
            DataTable dataTable = new DataTable();
            //act
            List<Test> actual = dataTable.ToList<Test>();
            //assert
            actual.Should().BeNull();
        }

        [TestMethod]
        [TestCategory("DataTableExtension")]
        [TestProperty("DataTableExtension", "ToList")]
        public void ToList_將資料列為空DataTable轉型成List強型別物件_List資料為空但不能為空物件()
        {
            //arrange       
            List<Test> expected = new List<Test>();
            //act
            List<Test> actual = dataTableTest.ToList<Test>();
            //assert
            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        [TestCategory("DataTableExtension")]
        [TestProperty("DataTableExtension", "ToList")]
        public void ToList_將DataTable轉型成List強型別物件_內容資料必須完全相同()
        {
            //arrange
            DataRow dataRow = dataTableTest.NewRow();
            dataRow.SetField("StringColumn", "TEST");
            dataRow.SetField<int>("IntColumn", 123);
            dataRow.SetField<decimal>("DecimalColumn", 100);
            dataRow.SetField<long>("LongColumn", 123456789);
            dataRow.SetField<double>("DoubleColumn", 0.123);
            dataTableTest.Rows.Add(dataRow);
            List<Test> expected = new List<Test>() {  new Test
            {
                StringColumn = "TEST",
                IntColumn = 123,
                DecimalColumn = 100,
                LongColumn = 123456789,
                DoubleColumn = 0.123
            }};
            //act
            List<Test> actual = dataTableTest.ToList<Test>();
            //assert        
            actual.ShouldBeEquivalentTo(expected);
        }

        public class Test
        {
            public string StringColumn { get; set; }
            public int IntColumn { get; set; }
            public decimal DecimalColumn { get; set; }
            public long LongColumn { get; set; }
            public double DoubleColumn { get; set; }
        }
    }
}
