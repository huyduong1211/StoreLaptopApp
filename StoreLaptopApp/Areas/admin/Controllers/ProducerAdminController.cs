using DoAnChuyenNganhConnection;
using StoreLaptopApp.Models.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreLaptopApp.Areas.admin.Controllers
{
    public class ProducerAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: admin/Producer
        public ActionResult Index()
        {
            var ds = ProducerBus.DanhSachAdmin();
            return View(ds);
        }

        // GET: admin/Producer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: admin/Producer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Producer/Create
        [HttpPost]
        public ActionResult Create(Producer producer)
        {
            try
            {
                // TODO: Add insert logic here
                ProducerBus.ThemNsx(producer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: admin/Producer/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ProducerBus.ChiTietAdmin(id));
        }

        // POST: admin/Producer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Producer producer)
        {
            try
            {
                // TODO: Add update logic here
                ProducerBus.UpdateNsx(id, producer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: admin/Producer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ProducerBus.ChiTietAdmin(id));
        }

        // POST: admin/Producer/Delete/5
        [HttpPost]
        public ActionResult Delete(Producer producer)
        {
            try
            {
                // TODO: Add delete logic here
                ProducerBus.DeleteNsx( producer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
