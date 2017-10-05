using MVCWebNorthWind.Models;
using MVCWebNorthWind.Respositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebNorthWind.Tests.Mocket
{
    public class MocketCustomersRespository : IGenerRespository<Customers>
    {
        const string CsvFilePath = @"C:\Users\1704006\source\repos\TestRepository\MVCWebNorthWind\MVCWebNorthWind.Tests\CsvTestData\Product_Data.csv";
        public void Delete(Customers entity)
        {
            
        }

        public Customers FirstOrDefault(Func<Customers, bool> func)
        {
            return new Customers();
        }

        public IQueryable<Customers> GetAll()
        {
            using (var sw = new StreamReader(CsvFilePath))
            {
                using (var reader = new CsvHelper.CsvReader(sw))
                {
                    return reader.GetRecords<Customers>().AsQueryable();
                }
            }
        }
        public void Insert(Customers entity)
        {
            
        }

        public void Update(Customers entity)
        {
          
        }
    }
}
