using MVCWebNorthWind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebNorthWind.Services.Interface
{
    public interface IOrderService
    {
        int CreateOrder(Orders orders);
        void DeleteOrder(Orders orders);
        void EditOrder(Orders orders);
        IEnumerable<Orders> GetAllOrders();
    }
}
