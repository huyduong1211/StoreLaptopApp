using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreLaptopApp.Controllers
{
    public class ShopLaptopController : Controller
    {
        // GET: ShopLaptop
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Index3()
        {
            return View();
        }
        public ActionResult Index4()
        {
            return View();
        }


        // GET: ShopLaptop/Details/5
        public ActionResult Details()
        {
            
           
            return View();
        }

        

        // GET: ShopLaptop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopLaptop/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopLaptop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShopLaptop/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopLaptop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShopLaptop/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
