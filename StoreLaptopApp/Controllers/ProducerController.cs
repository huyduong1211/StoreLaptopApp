using PagedList;
using StoreLaptopApp.Models.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreLaptopApp.Controllers
{
    public class ProducerController : Controller
    {
        // GET: Producer
        public ActionResult Index(int id ,int page = 1, int pagesize = 4)
        {
            var ds = ProducerBus.ChiTiet(id).ToPagedList(page, pagesize);
            return View(ds);
        }
    }
}