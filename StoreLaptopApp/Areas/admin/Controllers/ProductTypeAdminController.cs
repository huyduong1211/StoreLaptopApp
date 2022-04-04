using DoAnChuyenNganhConnection;
using StoreLaptopApp.Models.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreLaptopApp.Areas.admin.Controllers
{
    public class ProductTypeAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: admin/ProductType
        public ActionResult Index()
        {
            var ds = ProductTypeBus.DanhSachAdmin();
            return View(ds);
        }

        // GET: admin/ProductType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: admin/ProductType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/ProductType/Create
        [HttpPost]
        public ActionResult Create(ProductType productType)
        {
            try
            {
                // TODO: Add insert logic here
                ProductTypeBus.ThemLoai(productType);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: admin/ProductType/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ProductTypeBus.ChiTietAdmin(id));
        }

        // POST: admin/ProductType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductType productType)
        {
            try
            {
                // TODO: Add update logic here
                ProductTypeBus.UpdateLoai(id,productType);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();      
            }
        }

        // GET: admin/ProductType/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ProductTypeBus.ChiTietAdmin(id));
        }

        // POST: admin/ProductType/Delete/5
        [HttpPost]
        public ActionResult Delete(ProductType productType)
        {
            try
            {
                // TODO: Add delete logic here
                ProductTypeBus.DeleteLoai(productType);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
