using ShopOn.CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.BusinessLayer.Contracts
{
    public interface IOrderManager
    {
        Order GetOrder(int orderId);
        Order AddOrder(Order order);
        IEnumerable<Order> GetOrderByCustomerId(int CustomerId);
    }
}
