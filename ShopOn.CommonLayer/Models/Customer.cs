using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.CommonLayer.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Int64 MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public Company company { get; set; }

        private List<Order> orders = new List<Order>();

        /// <summary>
        /// Method to add orders
        /// </summary>
        /// <param name="order"></param>
        public void AddOrder(Order order)
        {
            this.orders.Add(order);
        }
        /// <summary>
        /// Method to get orders
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> GetOrders()
        {
            return this.orders;
        }

        public virtual double GetOrderTotal()
        {
            double total = 0;
            foreach (var order in this.orders)
            {
                total += order.GetOrderTotal();
            }
            return total;
        }
    }
}
