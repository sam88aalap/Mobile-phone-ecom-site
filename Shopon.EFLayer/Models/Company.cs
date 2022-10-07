using System;
using System.Collections.Generic;

#nullable disable

namespace Shopon.EFLayer.Models
{
    public partial class Company
    {
        public Company()
        {
            Products = new HashSet<Product>();
        }

        public int Companyid { get; set; }
        public string Companyname { get; set; }
        public string Companystatus { get; set; }
        public bool? Isdeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
