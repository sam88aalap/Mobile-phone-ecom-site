using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnEFLayer.Models
{
    public class Bank
    {
        public Bank()
        {
            this.Offers = new List<Offer>();
        }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string City { get; set; }
        public string IFSC { get; set; }

        public ICollection<Offer> Offers { get; set; }
    }
}
