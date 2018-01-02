using MVCWebNorthWind.DTOs;
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
        int CreateOrder(OrderDTO orders);
        void DeleteOrder(OrderDTO orders);
        void EditOrder(OrderDTO orders);
        IEnumerable<OrderDTO> GetAllOrders();
    }
}
