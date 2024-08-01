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
    public class EcoFriendlyAdminUsersController : Controller
    {
        private DBEcoFriendlyStoreEntities db = new DBEcoFriendlyStoreEntities();

        // GET: EcoFriendlyAdminUsers
        public ActionResult Index(string _name)
        {
            if (_name == null)
            {
                return View(db.EcoFriendlyAdminUsers.ToList());
            }
            else
            {
                return View(db.EcoFriendlyAdminUsers.Where(s => s.NameUser.Contains(_name)).ToList());
            }
        }

        // GET: EcoFriendlyAdminUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoFriendlyAdminUser ecoFriendlyAdminUser = db.EcoFriendlyAdminUsers.Find(id);
            if (ecoFriendlyAdminUser == null)
            {
                return HttpNotFound();
            }
            return View(ecoFriendlyAdminUser);
        }

        // GET: EcoFriendlyAdminUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EcoFriendlyAdminUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NameUser,RoleUser,PasswordUser")] EcoFriendlyAdminUser ecoFriendlyAdminUser)
        {
            if (ModelState.IsValid)
            {
                db.EcoFriendlyAdminUsers.Add(ecoFriendlyAdminUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ecoFriendlyAdminUser);
        }

        // GET: EcoFriendlyAdminUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoFriendlyAdminUser ecoFriendlyAdminUser = db.EcoFriendlyAdminUsers.Find(id);
            if (ecoFriendlyAdminUser == null)
            {
                return HttpNotFound();
            }
            return View(ecoFriendlyAdminUser);
        }

        // POST: EcoFriendlyAdminUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameUser,RoleUser,PasswordUser")] EcoFriendlyAdminUser ecoFriendlyAdminUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ecoFriendlyAdminUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ecoFriendlyAdminUser);
        }

        // GET: EcoFriendlyAdminUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoFriendlyAdminUser ecoFriendlyAdminUser = db.EcoFriendlyAdminUsers.Find(id);
            if (ecoFriendlyAdminUser == null)
            {
                return HttpNotFound();
            }
            return View(ecoFriendlyAdminUser);
        }

        // POST: EcoFriendlyAdminUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EcoFriendlyAdminUser ecoFriendlyAdminUser = db.EcoFriendlyAdminUsers.Find(id);
            db.EcoFriendlyAdminUsers.Remove(ecoFriendlyAdminUser);
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
