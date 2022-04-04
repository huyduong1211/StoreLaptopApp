using DoAnChuyenNganhConnection;
using StoreLaptopApp.Models.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreLaptopApp.Areas.admin.Controllers
{
    public class ProductAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: admin/Product
        public ActionResult Index()
        {
            var ds= ShopLaptopBus.DanhSachAdmin();
            return View(ds);
        }

        // GET: admin/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: admin/Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                ShopLaptopBus.Them(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ShopLaptopBus.ChiTietAdmin(id));
        }

        // POST: admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                // TODO: Add update logic here
                ShopLaptopBus.Update(id, product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: admin/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ShopLaptopBus.ChiTietAdmin(id));
        }

        // POST: admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete( Product product)
        {
            try
            {
                // TODO: Add delete logic here
                ShopLaptopBus.DeleteSp( product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
