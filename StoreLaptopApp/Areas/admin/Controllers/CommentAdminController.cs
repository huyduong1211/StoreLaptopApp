using DoAnChuyenNganhConnection;
using StoreLaptopApp.Models.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreLaptopApp.Areas.admin.Controllers
{
    public class CommentAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: admin/CommentAdmin
        public ActionResult Index()
        {
            var ds = CommentBus.DanhSachAdmin();
            return View(ds);
        }

        // GET: admin/CommentAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: admin/CommentAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/CommentAdmin/Create
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

        // GET: admin/CommentAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(CommentBus.ChiTiet(id));
        }

        // POST: admin/CommentAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Comment comment)
        {
            try
            {
                // TODO: Add update logic here
                CommentBus.UpdateAdmin(id, comment);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: admin/CommentAdmin/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: admin/CommentAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(FormCollection collection)
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