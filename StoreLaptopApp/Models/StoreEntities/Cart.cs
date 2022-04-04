using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.StoreEntities
{
    public class CartItem
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }

    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get{ return items; }
        }
        public void Add(Product product, int quantity = 1)
        {
            var item = items.FirstOrDefault(p => p.Product.Id == product.Id);
            if(item == null)
            {
                items.Add(new CartItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
            }
        }
        public void Update_Quantity_Shopping(int id, int quantity)
        {
            var item = items.Find(s => s.Product.Id == id);
            if(item != null)
            {
                item.Quantity = quantity;
            }
        }
        public String Total_Modey()
        {
            var total = items.Sum(s => s.Product.Price * s.Quantity);
            return string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", total);
        }
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s.Product.Id == id);
        }
        public int Total_Quantity()
        {
            return items.Count;
        }
        public void ClearCart()
        {
            items.Clear();
        }

        internal void Add(DoAnChuyenNganhConnection.Product pro)
        {
            throw new NotImplementedException();
        }
        
    }
}