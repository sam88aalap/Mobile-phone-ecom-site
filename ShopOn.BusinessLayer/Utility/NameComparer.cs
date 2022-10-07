using ShopOn.CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.BusinessLayer.Utility
{
    public class NameComparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return x.ProductName.CompareTo(y.ProductName);
        }
    }
}
