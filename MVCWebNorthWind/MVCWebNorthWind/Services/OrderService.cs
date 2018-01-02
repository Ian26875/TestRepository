using MVCWebNorthWind.Models;
using MVCWebNorthWind.Respositories.Interface;
using MVCWebNorthWind.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebNorthWind.Services
{
    public class OrderService : IOrderService
    {
        private IGenerRespository<Orders> _ordersRespository;

        public OrderService(IGenerRespository<Orders> ordersRespository)
        {
            _ordersRespository = ordersRespository;
        }

        public int CreateOrder(Orders orders)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Orders orders)
        {
            throw new NotImplementedException();
        }

        public void EditOrder(Orders orders)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            throw new NotImplementedException();
        }
    }
}