using StoreLaptopApp.Models;
using StoreLaptopApp.Models.StoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreLaptopApp.Controllers
{
    public class CartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cart
        public CartItem GetCartItem()
        {
            CartItem cartItem = Session["CartItem"] as CartItem;
            if(cartItem == null || Session["CartItem"]== null)
            {
                cartItem = new CartItem();
                Session["CartItem"] = cartItem;
            }
            return cartItem;
        }
        public ActionResult Index(int id)
        {
            var pro = db.Products.SingleOrDefault(s => s.Id == id);
            if (pro != null)
            {
                GetCartItem().Add(pro);
            }
            return View();
        }
        public ActionResult Add(int id)
        {
            var pro = db.Products.SingleOrDefault(s => s.Id == id);
            if (pro != null)
            {
                GetCartItem().Add(pro);
            }
            return RedirectToAction("Show", "Cart");
        }
        public ActionResult Show(int id)
        {

            if (Session["CartItem"] == null)
                return RedirectToAction("Show", "Cart");
            CartItem cartItem = Session["CartItem"] as CartItem;
            return View(cartItem);
        }
    }
}