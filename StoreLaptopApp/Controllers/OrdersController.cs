using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using StoreLaptopApp.Models;
using StoreLaptopApp.Models.StoreEntities;

namespace StoreLaptopApp.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            string userid = User.Identity.GetUserId().ToString();
            var orders = db.Orders.Where(u => u.CustomerId == userid).Include(o => o.Customer).Include(o => o.Employees);
            return View(orders.ToList());
        }
    }
}
