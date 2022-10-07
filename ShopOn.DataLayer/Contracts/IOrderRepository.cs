using ShopOn.CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopon.DataLayer.Contracts
{
     public interface IOrderRepository
    {
        /// <summary>
        /// method to get order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Order GetOrder(int orderId);
        Order AddOrder(Order order);
        IEnumerable<Order> GetOrderByCustomerId(int CustomerId);

    }
}
