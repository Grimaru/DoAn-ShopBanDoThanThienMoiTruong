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
    public class EcoFriendlyOrderProesController : Controller
    {
        private DBEcoFriendlyStoreEntities db = new DBEcoFriendlyStoreEntities();

        // GET: EcoFriendlyOrderProes
        public ActionResult Index()
        {
            var ecoFriendlyOrderProes = db.EcoFriendlyOrderProes.Include(e => e.EcoFriendlyCustomer);
            return View(ecoFriendlyOrderProes.ToList());
        }

        // GET: EcoFriendlyOrderProes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoFriendlyOrderPro ecoFriendlyOrderPro = db.EcoFriendlyOrderProes.Find(id);
            if (ecoFriendlyOrderPro == null)
            {
                return HttpNotFound();
            }
            return View(ecoFriendlyOrderPro);
        }

        // GET: EcoFriendlyOrderProes/Create
        public ActionResult Create()
        {
            ViewBag.IDCus = new SelectList(db.EcoFriendlyCustomers, "IDCus", "NameCus");
            return View();
        }

        // POST: EcoFriendlyOrderProes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DateOrder,IDCus,AddressDeliverry")] EcoFriendlyOrderPro ecoFriendlyOrderPro)
        {
            if (ModelState.IsValid)
            {
                db.EcoFriendlyOrderProes.Add(ecoFriendlyOrderPro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCus = new SelectList(db.EcoFriendlyCustomers, "IDCus", "NameCus", ecoFriendlyOrderPro.IDCus);
            return View(ecoFriendlyOrderPro);
        }

        // GET: EcoFriendlyOrderProes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoFriendlyOrderPro ecoFriendlyOrderPro = db.EcoFriendlyOrderProes.Find(id);
            if (ecoFriendlyOrderPro == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCus = new SelectList(db.EcoFriendlyCustomers, "IDCus", "NameCus", ecoFriendlyOrderPro.IDCus);
            return View(ecoFriendlyOrderPro);
        }

        // POST: EcoFriendlyOrderProes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DateOrder,IDCus,AddressDeliverry")] EcoFriendlyOrderPro ecoFriendlyOrderPro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ecoFriendlyOrderPro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCus = new SelectList(db.EcoFriendlyCustomers, "IDCus", "NameCus", ecoFriendlyOrderPro.IDCus);
            return View(ecoFriendlyOrderPro);
        }

        // GET: EcoFriendlyOrderProes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoFriendlyOrderPro ecoFriendlyOrderPro = db.EcoFriendlyOrderProes.Find(id);
            if (ecoFriendlyOrderPro == null)
            {
                return HttpNotFound();
            }
            return View(ecoFriendlyOrderPro);
        }

        // POST: EcoFriendlyOrderProes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EcoFriendlyOrderPro ecoFriendlyOrderPro = db.EcoFriendlyOrderProes.Find(id);
            db.EcoFriendlyOrderProes.Remove(ecoFriendlyOrderPro);
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
