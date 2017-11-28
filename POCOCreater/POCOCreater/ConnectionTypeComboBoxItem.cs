using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCOCreater
{
    public class ConnectionTypeComboBoxItem
    {
        public IDbConnection Connection { get; set; }
        public string Name { get; set; }
    }
}
