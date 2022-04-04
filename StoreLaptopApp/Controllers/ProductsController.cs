using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreLaptopApp.Models;
using StoreLaptopApp.Models.StoreEntities;

namespace StoreLaptopApp.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        private List<Product> listProducts;
        public ProductsController()
        {
            listProducts = new List<Product>();
            listProducts.Add(new Product()
            {
                Id = 1,
                Name ="LaptopAsus",
                Description = "Máy tính sách tay chính hãng",
                PublicYear = 2018,
                Price = 17000000,
                Cover = "Content/images/laptop1.jpg"

            });
            listProducts.Add(new Product()
            {
                Id = 2,
                Name = "LaptopAcer",
                Description = "Máy tính sách tay chính hãng",
                PublicYear = 2019,
                Price = 19000000,
                Cover = "Content/images/laptop2.jpg"

            });
            listProducts.Add(new Product()
            {
                Id = 3,
                Name = "LaptopDell",
                Description = "Máy tính sách tay chính hãng",
                PublicYear = 2018,
                Price = 18000000,
                Cover = "Content/images/Laptopdell.jpg"

            });
            listProducts.Add(new Product()
            {
                Id = 4,
                Name = "LaptopDell",
                Description = "Máy tính sách tay chính hãng",
                PublicYear = 2018,
                Price = 15000000,
                Cover = "Content/images/laptopdell1.jpg"

            });
            listProducts.Add(new Product()
            {
                Id = 5,
                Name = "LaptopDellG3",
                Description = "Máy tính sách tay chính hãng",
                PublicYear = 2018,
                Price = 20000000,
                Cover = "Content/images/laptopdellg3.jpg"

            });
            listProducts.Add(new Product()
            {
                Id = 6,
                Name = "LaptopDellXPS13",
                Description = "Máy tính sách tay chính hãng",
                PublicYear = 2018,
                Price = 21000000,
                Cover = "Content/images/laptopdellxps13.jpg"

            });
            listProducts.Add(new Product()
            {
                Id = 7,
                Name = "LaptopAsusRodTrix",
                Description = "Máy tính sách tay chính hãng",
                PublicYear = 2018,
                Price = 25000000,
                Cover = "Content/images/laptopasusrodtrix.jpg"

            });
            listProducts.Add(new Product()
            {
                Id = 8,
                Name = "LaptopAsusViVoBook",
                Description = "Máy tính sách tay chính hãng",
                PublicYear = 2018,
                Price = 19000000,
                Cover = "Content/images/laptopasusvivobook.jpg"

            });
            listProducts.Add(new Product()
            {
                Id = 9,
                Name = "LaptopAsusZenbook13",
                Description = "Máy tính sách tay chính hãng",
                PublicYear = 2018,
                Price = 18500000,
                Cover = "Content/images/laptopasuszenbook13.jpg"

            });
            listProducts.Add(new Product()
            {
                Id = 10,
                Name = "MacbookproM1",
                Description = "Máy tính sách tay chính hãng",
                PublicYear = 2021,
                Price = 45000000,
                Cover = "Content/images/macbookm1.jpg"

            });
            listProducts.Add(new Product()
            {
                Id = 11,
                Name = "Macbookpro2018",
                Description = "Máy tính sách tay chính hãng",
                PublicYear = 2018,
                Price = 30000000,
                Cover = "Content/images/macbookpro2018.jpg"

            });
            listProducts.Add(new Product()
            {
                Id = 12,
                Name = "Macbookpro2020",
                Description = "Máy tính sách tay chính hãng",
                PublicYear = 2020,
                Price = 35000000,
                Cover = "Content/images/macbookpro2020.jpg"

            });

        }

        public ActionResult Index()
        {
            
            return View(listProducts);
        }


        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

       

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,PublicYear,Price,Cover")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,PublicYear,Price,Cover")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
