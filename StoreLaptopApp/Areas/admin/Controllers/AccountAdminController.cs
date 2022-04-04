
using DoAnChuyenNganhConnection;
using StoreLaptopApp.Models.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreLaptopApp.Areas.admin.Controllers
{
    public class AccountAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: admin/Account
        public ActionResult Index()
        {
            var ds = AccountBus.DanhSachAdmin();
            return View(ds);
        }

        // GET: admin/Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: admin/Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Account/Create
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

        // GET: admin/Account/Edit/5
        public ActionResult Edit(string id)
        {
            return View(AccountBus.ChiTietAdmin(id));
        }

        // POST: admin/Account/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, AspNetUser asp)
        {
            try
            {
                // TODO: Add update logic here
                AccountBus.Update(id, asp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: admin/Account/Delete/5
        public ActionResult Delete(string id)
        {
            return View(AccountBus.ChiTietAdmin(id));
        }

        // POST: admin/Account/Delete/5
        [HttpPost]
        public ActionResult Delete(AspNetUser asp)
        {
            try
            {
                // TODO: Add delete logic here
                AccountBus.Delete(asp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}