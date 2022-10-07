using System;
using System.Collections.Generic;

#nullable disable

namespace ShopOnEFLayer.Models
{
    public partial class Product
    {
        public int Pid { get; set; }
        public string Productname { get; set; }
        public double? Price { get; set; }
        public int? Companyid { get; set; }
        public int? Categoryid { get; set; }
        public string Availablestatus { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Category Category { get; set; }
        public virtual Company Company { get; set; }
    }
}
