using PagedList;
using StoreLaptopApp.Models.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreLaptopApp.Controllers
{
    public class ProductTypeController : Controller
    {
        // GET: ProductType
        public ActionResult Index(int id, int page = 1, int pagesize = 4)
        {
            var ds = ProductTypeBus.ChiTiet(id).ToPagedList(page, pagesize);
            return View(ds);
        }
    }
}