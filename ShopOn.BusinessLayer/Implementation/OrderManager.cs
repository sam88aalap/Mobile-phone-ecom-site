using Shopon.DataLayer.Contracts;
using ShopOn.BusinessLayer.Contracts;
using ShopOn.CommonLayer.Models;
using ShopOn.DataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopon.BusinessLayer.Implementation
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public Order AddOrder(Order order)
            => this.orderRepository.AddOrder(order);

        public Order GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrderByCustomerId(int CustomerId)
        {
            throw new NotImplementedException();
        }
    }
}
