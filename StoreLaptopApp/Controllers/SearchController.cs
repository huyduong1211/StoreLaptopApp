using PagedList;
using StoreLaptopApp.Models.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreLaptopApp.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string key)
        {
            var db = ShopLaptopBus.Search(key);
            return View(db);
        }
    }
}