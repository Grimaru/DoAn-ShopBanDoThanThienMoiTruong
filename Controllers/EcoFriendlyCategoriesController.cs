using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDoAn__Demo1_;

namespace WebDoAn__Demo1_.Controllers
{
    public class EcoFriendlyCategoriesController : Controller
    {
        private DBEcoFriendlyStoreEntities db = new DBEcoFriendlyStoreEntities();

        public PartialViewResult CategoryPartial()
        {
            var cateList = db.EcoFriendlyCategories.ToList();
            return PartialView(cateList);
        }

        // GET: EcoFriendlyCategories
        public ActionResult Index(string _name)
        {
            if (_name == null)
            {
                return View(db.EcoFriendlyCategories.ToList());
            }
            else
            {
                return View(db.EcoFriendlyCategories.Where(s => s.NameCate.Contains(_name)).ToList());
            }
        }

        // GET: EcoFriendlyCategories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoFriendlyCategory ecoFriendlyCategory = db.EcoFriendlyCategories.Find(id);
            if (ecoFriendlyCategory == null)
            {
                return HttpNotFound();
            }
            return View(ecoFriendlyCategory);
        }

        // GET: EcoFriendlyCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EcoFriendlyCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IDCate,NameCate")] EcoFriendlyCategory ecoFriendlyCategory)
        {
            if (ModelState.IsValid)
            {
                db.EcoFriendlyCategories.Add(ecoFriendlyCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ecoFriendlyCategory);
        }

        // GET: EcoFriendlyCategories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoFriendlyCategory ecoFriendlyCategory = db.EcoFriendlyCategories.Find(id);
            if (ecoFriendlyCategory == null)
            {
                return HttpNotFound();
            }
            return View(ecoFriendlyCategory);
        }

        // POST: EcoFriendlyCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IDCate,NameCate")] EcoFriendlyCategory ecoFriendlyCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ecoFriendlyCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ecoFriendlyCategory);
        }

        // GET: EcoFriendlyCategories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoFriendlyCategory ecoFriendlyCategory = db.EcoFriendlyCategories.Find(id);
            if (ecoFriendlyCategory == null)
            {
                return HttpNotFound();
            }
            return View(ecoFriendlyCategory);
        }

        // POST: EcoFriendlyCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EcoFriendlyCategory ecoFriendlyCategory = db.EcoFriendlyCategories.Find(id);
            db.EcoFriendlyCategories.Remove(ecoFriendlyCategory);
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
