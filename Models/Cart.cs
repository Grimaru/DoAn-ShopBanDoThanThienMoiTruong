using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDoAn__Demo1_;

namespace WebDoAn__Demo1_.Models
{
    public class CartItem
    {
        public EcoFriendlyProduct _product { get; set; }
        public int _quantity { get; set; }
        public EcoFriendlyOrderPro _order { get; set; }
    }

    public class Cart
    {
        List<CartItem> items = new List<CartItem>();

        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }

        public void Add(EcoFriendlyProduct pro, int _quantity = 1)
        {
            var item = items.FirstOrDefault(s => s._product.ProductID == pro.ProductID);
            if (item == null)
            {
                items.Add(new CartItem { _product = pro, _quantity = _quantity });
            }
            else
            {
                item._quantity += _quantity;
            }
        }

        public void Update_Quantity_Shopping(int id, int _quantity)
        {
            var item = items.Find(s => s._product.ProductID == id);
            if (item != null)
            {
                if (items.Find(s => s._product.Quantity > _quantity) != null)
                    item._quantity = _quantity;
                else item._quantity = 1;
            }
        }

        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s._product.ProductID == id);
        }

        public void ClearCart()
        {
            items.Clear();
        }

        public double Total_Money()
        {
            var total = items.Sum(s => s._product.Price * s._quantity);
            return (double)total;
        }

        public int Total_quantity_in_Cart()
        {
            return items.Sum(s => s._quantity);
        }
    }
}
