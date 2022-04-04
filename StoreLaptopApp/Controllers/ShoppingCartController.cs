using StoreLaptopApp.Models;
using StoreLaptopApp.Models.Bus;
using StoreLaptopApp.Models.StoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace StoreLaptopApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        //Add item to Cart
        public ActionResult AddToCart(int id) 
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var pro = db.Products.SingleOrDefault(s => s.Id == id);
            if (pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        //Cart Page
        public ActionResult ShowToCart()
        {
            GetCart();
            if (Session["Cart"] == null)
            {
                return RedirectToAction("ShowToCart","ShoppingCart");
            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }     
        //Cart Quantity Update 
        public ActionResult UpdateQuantityCart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_product = int.Parse(form["ID_Product"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity_Shopping(id_product, quantity);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        //Remove item in Cart
        public ActionResult RemoveItem(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        //Bag total item in Cart
        public PartialViewResult BagCart()
        {
            int t_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if(cart != null)
            {
                t_item = cart.Total_Quantity();
            }
            ViewBag.infoCart = t_item;
            return PartialView("BagCart");
        }
        //Checkout Cart to Order
        //[Authorize]
        public ActionResult CheckOut(FormCollection form)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            Cart cart = Session["Cart"] as Cart;
            Order order = new Order();
            order.OrderDate = DateTime.Now;
            //order.CustomerId = User.Identity.GetUserId();
            order.CustomerId = User.Identity.GetUserId().ToString();
            order.EmployeesId = 1;
            order.Confirmed = false;
            order.Delivered = false;
            dbContext.Orders.Add(order);

            OrderDetail orderDetail;
            if (true)
            {
                foreach (var item in cart.Items)
                {
                    orderDetail = new OrderDetail();
                    orderDetail.OrderId = order.OrderId;
                    orderDetail.ProductId = item.Product.Id;
                    orderDetail.Quantity = item.Quantity;
                    int quantity = item.Quantity;
                    double price = item.Product.Price;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.TotalPrice = price * quantity;
                    dbContext.OrderDetails.Add(orderDetail);
                }
            }
            dbContext.SaveChanges();
            cart.ClearCart();
            return RedirectToAction("Shopping_Success", "ShoppingCart");
        }
        //Shopping Success
        public ActionResult Shopping_Success()
        {
            return View();
        }
    }
}