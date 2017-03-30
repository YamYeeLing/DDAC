using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DDAC.Models;

namespace DDAC.Controllers
{
    public class ShiptransactionsController : Controller
    {
        private DDACEntities5 db = new DDACEntities5();

        // GET: Shiptransactions
        public ActionResult Index()
        {
            return View(db.Shiptransactions.ToList());
        }

        // GET: Shiptransactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shiptransaction shiptransaction = db.Shiptransactions.Find(id);
            if (shiptransaction == null)
            {
                return HttpNotFound();
            }
            return View(shiptransaction);
        }

        // GET: Shiptransactions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shiptransactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipId,ShipName,DepartLocation,DestinationLocation")] Shiptransaction shiptransaction)
        {
            if (ModelState.IsValid)
            {
                db.Shiptransactions.Add(shiptransaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shiptransaction);
        }

        // GET: Shiptransactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shiptransaction shiptransaction = db.Shiptransactions.Find(id);
            if (shiptransaction == null)
            {
                return HttpNotFound();
            }
            return View(shiptransaction);
        }

        // POST: Shiptransactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipId,ShipName,DepartLocation,DestinationLocation")] Shiptransaction shiptransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shiptransaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shiptransaction);
        }

        // GET: Shiptransactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shiptransaction shiptransaction = db.Shiptransactions.Find(id);
            if (shiptransaction == null)
            {
                return HttpNotFound();
            }
            return View(shiptransaction);
        }

        // POST: Shiptransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shiptransaction shiptransaction = db.Shiptransactions.Find(id);
            db.Shiptransactions.Remove(shiptransaction);
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
