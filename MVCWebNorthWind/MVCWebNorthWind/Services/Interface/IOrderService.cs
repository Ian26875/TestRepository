using MVCWebNorthWind.DTOs;
using MVCWebNorthWind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebNorthWind.Services.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Creates the order.
        /// </summary>
        /// <param name="orders">The orders.</param>
        /// <returns></returns>
        int CreateOrder(OrderDTO orders);
        /// <summary>
        /// Deletes the order.
        /// </summary>
        /// <param name="orders">The orders.</param>
        void DeleteOrder(OrderDTO orders);
        /// <summary>
        /// Edits the order.
        /// </summary>
        /// <param name="orders">The orders.</param>
        void EditOrder(OrderDTO orders);
        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <returns></returns>
        IEnumerable<OrderDTO> GetAllOrders();
    }
}
