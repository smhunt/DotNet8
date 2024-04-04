using System;
using System.Collections.Generic;
using System.Linq;

namespace CartWebApp.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; } = new List<CartItem>();

        public void AddItem(Product product, int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem(product, quantity));
            }
        }

        public void RemoveItem(int productId)
        {
            var item = Items.FirstOrDefault(i => i.Product.Id == productId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }

        public decimal TotalPrice => Items.Sum(i => i.TotalPrice);
    }
}
