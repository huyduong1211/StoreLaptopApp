using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreLaptopApp.Models;
using StoreLaptopApp.Models.StoreEntities;

namespace StoreLaptopApp.Areas.admin.Controllers
{
    public class OrderAdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize(Roles = "Admin")]
        // GET: admin/OrderAdmin
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.Employees);
            return View(orders.ToList());
        }

        // GET: admin/OrderAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderdetail = db.OrderDetails.Where(o=>o.OrderId == id).Include(o=>o.Product).ToList();
            if (orderdetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = id;
            ViewBag.Confirm = db.Orders.Find(id).Confirmed;
            ViewBag.Delivery = db.Orders.Find(id).Delivered;
            return View(orderdetail);
        }
        //submit order
        public ActionResult SubmitOrder(FormCollection form)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            int id_order = int.Parse(form["ID_Order"]);
            Order order = dbContext.Orders.FirstOrDefault(o => o.OrderId == id_order);
            order.Confirmed = true;
            dbContext.SaveChanges();
            return RedirectToAction("Index", "OrderAdmin");
        }
        //delivery order
        public ActionResult DeliveryOrder(FormCollection form)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            int id_order = int.Parse(form["ID_Order"]);
            Order order = dbContext.Orders.FirstOrDefault(o => o.OrderId == id_order);
            order.Delivered = true;
            dbContext.SaveChanges();
            return RedirectToAction("Index", "OrderAdmin");
        }
    }
}
