using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.CommonLayer.Models
{
    public class Product 
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public string Availability { get; set; }

        public int CompanyId { get; set; }
        public int CategoryId { get; set; }

        public string ImageUrl { get; set; }

        //public Categ MyProperty { get; set; }

        public Company Company { get; set; }
        //public int CompareTo(Product other)
        //{
        //    if(this.ProductId > other.ProductId)
        //    {
        //        return 1;
        //    }
        //    else if(this.ProductId < other.ProductId)
        //    {
        //        return -1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
    }
}
