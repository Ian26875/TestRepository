using AutoMapper;
using MVCWebNorthWind.DTOs;
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

        public int CreateOrder(OrderDTO orders)
        {
            if (orders == null)
            {
                throw new ArgumentNullException(nameof(orders));
            }
            var entity = Mapper.Map<Orders>(orders);
            var model=this._ordersRespository.Insert(entity);
            var orderId = model.OrderID;
            return orderId;
        }

        public void DeleteOrder(OrderDTO orders)
        {
            throw new NotImplementedException();
        }

        public void EditOrder(OrderDTO orders)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            throw new NotImplementedException();
        }



    }
}