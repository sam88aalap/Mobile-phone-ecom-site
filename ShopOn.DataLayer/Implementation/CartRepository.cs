using ShopOn.CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.DataLayer.Implementation
{
    public class CartRepository
    {
        //List<Cart> carts = new List<Cart>();
        ObservableCollection<Cart> carts = new ObservableCollection<Cart>();
        private int cartCount = 0;
        public void AddCart(Cart cart)
        {
            carts.Add(cart);
            carts.CollectionChanged += Carts_CollectionChanged;
        }

        private void Carts_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                cartCount++;
            }
            else if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                cartCount--;
            }
        }

        public int GetCartCount()
        {
            return carts.Count;
        }

        public double GetCartTotal()
        {
            return 0;
        }

        public void RemoveCart(int cartId)
        {
            
        }
    }
}
