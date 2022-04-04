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

namespace StoreLaptopApp.Controllers
{
    public class OrderDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<OrderDetail> orderDetail = db.OrderDetails.Where(o => o.OrderId == id).Include(o => o.Product).ToList();
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }
    }
}
