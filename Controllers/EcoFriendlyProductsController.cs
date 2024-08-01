using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDoAn__Demo1_;
using PagedList;
using PagedList.Mvc;

namespace WebDoAn__Demo1_.Controllers
{
    public class EcoFriendlyProductsController : Controller
    {
        private DBEcoFriendlyStoreEntities db = new DBEcoFriendlyStoreEntities();

        // GET: EcoFriendlyProducts
        public ActionResult Index()
        {
            var ecoFriendlyProducts = db.EcoFriendlyProducts.Include(e => e.EcoFriendlyCategory);
            return View(ecoFriendlyProducts.ToList());
        }

        public ActionResult InfoProduct()
        {
            return View(db.EcoFriendlyProducts.ToList());
        }

        public ActionResult Product(string category, int? page, double min = double.MinValue, double max = double.MaxValue)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);
            if (category == null)
            {
                var productList = db.EcoFriendlyProducts.OrderByDescending(x => x.NamePro);

                return View(productList.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var productList = db.EcoFriendlyProducts.OrderByDescending(x => x.NamePro).Where(x => x.Category == category);
                return View(productList.ToPagedList(pageNum, pageSize));
            }
        }

        // GET: EcoFriendlyProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoFriendlyProduct ecoFriendlyProduct = db.EcoFriendlyProducts.Find(id);
            if (ecoFriendlyProduct == null)
            {
                return HttpNotFound();
            }
            return View(ecoFriendlyProduct);
        }

        // GET: EcoFriendlyProducts/Create
        public ActionResult Create()
        {
            ViewBag.Category = new SelectList(db.EcoFriendlyCategories, "IDCate", "NameCate");
            return View();
        }

        // POST: EcoFriendlyProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,NamePro,DecriptionPro,Category,Price,ImagePro")] EcoFriendlyProduct ecoFriendlyProduct)
        {
            if (ModelState.IsValid)
            {
                db.EcoFriendlyProducts.Add(ecoFriendlyProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category = new SelectList(db.EcoFriendlyCategories, "IDCate", "NameCate", ecoFriendlyProduct.Category);
            return View(ecoFriendlyProduct);
        }

        // GET: EcoFriendlyProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoFriendlyProduct ecoFriendlyProduct = db.EcoFriendlyProducts.Find(id);
            if (ecoFriendlyProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category = new SelectList(db.EcoFriendlyCategories, "IDCate", "NameCate", ecoFriendlyProduct.Category);
            return View(ecoFriendlyProduct);
        }

        // POST: EcoFriendlyProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,NamePro,DecriptionPro,Category,Price,ImagePro")] EcoFriendlyProduct ecoFriendlyProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ecoFriendlyProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(db.EcoFriendlyCategories, "IDCate", "NameCate", ecoFriendlyProduct.Category);
            return View(ecoFriendlyProduct);
        }

        // GET: EcoFriendlyProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoFriendlyProduct ecoFriendlyProduct = db.EcoFriendlyProducts.Find(id);
            if (ecoFriendlyProduct == null)
            {
                return HttpNotFound();
            }
            return View(ecoFriendlyProduct);
        }

        // POST: EcoFriendlyProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EcoFriendlyProduct ecoFriendlyProduct = db.EcoFriendlyProducts.Find(id);
            db.EcoFriendlyProducts.Remove(ecoFriendlyProduct);
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
