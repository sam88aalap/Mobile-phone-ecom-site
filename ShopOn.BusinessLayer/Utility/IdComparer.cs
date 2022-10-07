using ShopOn.CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.BusinessLayer.Utility
{
    public class IdComparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            //if (x.ProductId > y.ProductId)
            //{
            //    return 1;
            //}
            //else if (x.ProductId < y.ProductId)
            //{
            //    return -1;
            //}
            //else
            //{
            //    return 0;
            //}
            return x.ProductId.CompareTo(y.ProductId);
        }
    }
}
