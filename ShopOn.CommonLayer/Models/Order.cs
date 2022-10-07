using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.CommonLayer.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer customer { get; set; }
        public double OrderTotal { get; set; }
        public string AspCustomerId { get; set; }

        private List<OrderItem> orderItems = new List<OrderItem>();

        /// <summary>
        /// Morthod to Add <paramref name="orderItem"/>
        /// </summary>
        /// <returns></returns>
        /// <param name="orderItem"></param>
        public void AddOrderItem(OrderItem orderItem)
        {
            this.orderItems.Add(orderItem);
        }

        /// <summary>
        /// Method to get orderitem
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderItem> GetOrderItem()
        {
            return this.orderItems;
        }

        public double GetOrderTotal()
        {
            double total = 0;
            foreach (var orderItem in this.orderItems)
            {
                total += orderItem.GetAmmount();
            }
            return total;
        }
    }
}
