using AutoMapper;
using MVCWebNorthWind.DTOs;
using MVCWebNorthWind.Models;
using MVCWebNorthWind.Respositories.Interface;
using MVCWebNorthWind.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// 
/// </summary>
namespace MVCWebNorthWind.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MVCWebNorthWind.Services.Interface.IOrderService" />
    public class OrderService : IOrderService
    {
        /// <summary>
        /// The orders respository
        /// </summary>
        private IGenerRespository<Orders> _ordersRespository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService" /> class.
        /// </summary>
        /// <param name="ordersRespository">The orders respository.</param>
        public OrderService(IGenerRespository<Orders> ordersRespository)
        {
            _ordersRespository = ordersRespository;
        }

        /// <summary>
        /// Creates the order.
        /// </summary>
        /// <param name="orders">The orders.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">orders</exception>
        public int CreateOrder(OrderDTO orders)
        {
            if (orders == null)
            {
                throw new ArgumentNullException(nameof(orders));
            }
            Orders entity = MapToOrders(orders);
            var model = this._ordersRespository.Insert(entity);
            var orderId = model.OrderID;
            return orderId;
        }

        /// <summary>
        /// Deletes the order.
        /// </summary>
        /// <param name="orders">The orders.</param>
        /// <exception cref="ArgumentNullException">orders</exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void DeleteOrder(OrderDTO orders)
        {
            if (orders == null)
            {
                throw new ArgumentNullException(nameof(orders));
            }
            if (orders.OrderID == default(int))
            {
                throw new InvalidOperationException();
            }
            var entity = MapToOrders(orders);
            this._ordersRespository.Delete(entity);
        }

        /// <summary>
        /// Edits the order.
        /// </summary>
        /// <param name="orders">The orders.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void EditOrder(OrderDTO orders)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<OrderDTO> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Maps to orders.
        /// </summary>
        /// <param name="orders">The orders.</param>
        /// <returns></returns>
        private Orders MapToOrders(OrderDTO orders)
        {
            return Mapper.Map<Orders>(orders);
        }

    }
}