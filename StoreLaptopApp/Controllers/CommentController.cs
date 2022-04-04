using Microsoft.AspNet.Identity;
using StoreLaptopApp.Models.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreLaptopApp.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Create(int masp, String Content, string IdAccount, string NameAccount)
        {
            CommentBus.ThemComment(masp, Content, User.Identity.GetUserId(), User.Identity.Name);
            return RedirectToAction("Details", "Product", new { Id = masp });
        }
        public ActionResult Index(int masp)
        {
            ViewBag.Id = masp;
            return View(CommentBus.DanhSach(masp));
        }
    }
}