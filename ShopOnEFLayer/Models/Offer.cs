using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnEFLayer.Models
{
    public class Offer
    {
        public int OfferId { get; set; }
        public int BankId { get; set; }
        public int Discount { get; set; }
        public string Remarks { get; set; }
        public string OfferType { get; set; }

        public Bank bank { get; set; }
    }
}
