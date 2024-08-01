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
    public class EcoFriendlyCustomersController : Controller
    {
        private DBEcoFriendlyStoreEntities db = new DBEcoFriendlyStoreEntities();

        // GET: EcoFriendlyCustomers
        public ActionResult Index(string _name)
        {
            if (_name == null)
            {
                return View(db.EcoFriendlyCustomers.ToList());
            }
            else
            {
                return View(db.EcoFriendlyCustomers.Where(s => s.NameCus.Contains(_name)).ToList());
            }
        }

        // GET: EcoFriendlyCustomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoFriendlyCustomer ecoFriendlyCustomer = db.EcoFriendlyCustomers.Find(id);
            if (ecoFriendlyCustomer == null)
            {
                return HttpNotFound();
            }
            return View(ecoFriendlyCustomer);
        }

        // GET: EcoFriendlyCustomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EcoFriendlyCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCus,NameCus,PhoneCus,EmailCus")] EcoFriendlyCustomer ecoFriendlyCustomer)
        {
            if (ModelState.IsValid)
            {
                db.EcoFriendlyCustomers.Add(ecoFriendlyCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ecoFriendlyCustomer);
        }

        // GET: EcoFriendlyCustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoFriendlyCustomer ecoFriendlyCustomer = db.EcoFriendlyCustomers.Find(id);
            if (ecoFriendlyCustomer == null)
            {
                return HttpNotFound();
            }
            return View(ecoFriendlyCustomer);
        }

        // POST: EcoFriendlyCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCus,NameCus,PhoneCus,EmailCus")] EcoFriendlyCustomer ecoFriendlyCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ecoFriendlyCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ecoFriendlyCustomer);
        }

        // GET: EcoFriendlyCustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoFriendlyCustomer ecoFriendlyCustomer = db.EcoFriendlyCustomers.Find(id);
            if (ecoFriendlyCustomer == null)
            {
                return HttpNotFound();
            }
            return View(ecoFriendlyCustomer);
        }

        // POST: EcoFriendlyCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EcoFriendlyCustomer ecoFriendlyCustomer = db.EcoFriendlyCustomers.Find(id);
            db.EcoFriendlyCustomers.Remove(ecoFriendlyCustomer);
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
