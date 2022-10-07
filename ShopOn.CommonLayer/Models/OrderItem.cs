using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.CommonLayer.Models
{
    public class OrderItem
    {
        public Product product { get; set; }
        public int PId { get; set; }
        public int Qty { get; set; }

        public double Amount { get; set; }

        /// <summary>
        /// method to get total ammount for each item
        /// </summary>
        /// <returns></returns>
        public double GetAmmount()
        {
            return product.ProductPrice * Qty;
        }
    }
}
