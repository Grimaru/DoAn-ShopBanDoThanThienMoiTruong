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
    public class EcoFriendlyOrderDetailsController : Controller
    {
        private DBEcoFriendlyStoreEntities db = new DBEcoFriendlyStoreEntities();

        // GET: EcoFriendlyOrderDetails
        public ActionResult Index()
        {
            var ecoFriendlyOrderDetails = db.EcoFriendlyOrderDetails.Include(e => e.EcoFriendlyOrderPro).Include(e => e.EcoFriendlyProduct);
            return View(ecoFriendlyOrderDetails.ToList());
        }

        // GET: EcoFriendlyOrderDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoFriendlyOrderDetail ecoFriendlyOrderDetail = db.EcoFriendlyOrderDetails.Find(id);
            if (ecoFriendlyOrderDetail == null)
            {
                return HttpNotFound();
            }
            return View(ecoFriendlyOrderDetail);
        }

        // GET: EcoFriendlyOrderDetails/Create
        public ActionResult Create()
        {
            ViewBag.IDOrder = new SelectList(db.EcoFriendlyOrderProes, "ID", "AddressDeliverry");
            ViewBag.IDProduct = new SelectList(db.EcoFriendlyProducts, "ProductID", "NamePro");
            return View();
        }

        // POST: EcoFriendlyOrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDProduct,IDOrder,Quantity,UnitPrice")] EcoFriendlyOrderDetail ecoFriendlyOrderDetail)
        {
            if (ModelState.IsValid)
            {
                db.EcoFriendlyOrderDetails.Add(ecoFriendlyOrderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDOrder = new SelectList(db.EcoFriendlyOrderProes, "ID", "AddressDeliverry", ecoFriendlyOrderDetail.IDOrder);
            ViewBag.IDProduct = new SelectList(db.EcoFriendlyProducts, "ProductID", "NamePro", ecoFriendlyOrderDetail.IDProduct);
            return View(ecoFriendlyOrderDetail);
        }

        // GET: EcoFriendlyOrderDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoFriendlyOrderDetail ecoFriendlyOrderDetail = db.EcoFriendlyOrderDetails.Find(id);
            if (ecoFriendlyOrderDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDOrder = new SelectList(db.EcoFriendlyOrderProes, "ID", "AddressDeliverry", ecoFriendlyOrderDetail.IDOrder);
            ViewBag.IDProduct = new SelectList(db.EcoFriendlyProducts, "ProductID", "NamePro", ecoFriendlyOrderDetail.IDProduct);
            return View(ecoFriendlyOrderDetail);
        }

        // POST: EcoFriendlyOrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDProduct,IDOrder,Quantity,UnitPrice")] EcoFriendlyOrderDetail ecoFriendlyOrderDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ecoFriendlyOrderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDOrder = new SelectList(db.EcoFriendlyOrderProes, "ID", "AddressDeliverry", ecoFriendlyOrderDetail.IDOrder);
            ViewBag.IDProduct = new SelectList(db.EcoFriendlyProducts, "ProductID", "NamePro", ecoFriendlyOrderDetail.IDProduct);
            return View(ecoFriendlyOrderDetail);
        }

        // GET: EcoFriendlyOrderDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoFriendlyOrderDetail ecoFriendlyOrderDetail = db.EcoFriendlyOrderDetails.Find(id);
            if (ecoFriendlyOrderDetail == null)
            {
                return HttpNotFound();
            }
            return View(ecoFriendlyOrderDetail);
        }

        // POST: EcoFriendlyOrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EcoFriendlyOrderDetail ecoFriendlyOrderDetail = db.EcoFriendlyOrderDetails.Find(id);
            db.EcoFriendlyOrderDetails.Remove(ecoFriendlyOrderDetail);
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
