using ShopOn.CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.BusinessLayer.Utility
{
    public class PriceComparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            //if (x.ProductPrice > y.ProductPrice)
            //{
            //    return 1;
            //}
            //else if (x.ProductPrice < y.ProductPrice)
            //{
            //    return -1;
            //}
            //else
            //{
            //    return 0;
            //}
            return x.ProductPrice.CompareTo(y.ProductPrice);
        }
    }
}
