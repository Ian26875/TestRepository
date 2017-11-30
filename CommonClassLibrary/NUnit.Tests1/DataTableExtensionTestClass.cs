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
            public override bool Equals(object obj)
            {
                var input = obj as Test;
                if (input == null)
                {
                    return false;
                }
                else
                {
                    var result = StringColumn == input.StringColumn
                        && IntColumn == input.IntColumn
                         && DecimalColumn == input.DecimalColumn
                           && LongColumn == input.LongColumn
                             && DoubleColumn == input.DoubleColumn;
                    return result;
                }
            }
        }

        [Test]
        [Category("DataTableExtension")]
        public void ToList_將DataTable轉型成List強型別物件_內容資料必須完全相同()
        {
            //arrange
            DataTable dataTableTest = new DataTable();
            dataTableTest.Columns.Add("StringColumn", typeof(string));
            dataTableTest.Columns.Add("IntColumn", typeof(int));
            dataTableTest.Columns.Add("DecimalColumn", typeof(decimal));
            dataTableTest.Columns.Add("LongColumn", typeof(long));
            dataTableTest.Columns.Add("DoubleColumn", typeof(double));
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
            Assert.That(actual,Is.EquivalentTo(expected));
   
        }
    }



}
