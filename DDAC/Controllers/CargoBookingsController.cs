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
    public class CargoBookingsController : Controller
    {
        private DDACEntities5 db = new DDACEntities5();

        // GET: CargoBookings
        public ActionResult Index()
        {
            var cargoBookings = db.CargoBookings.Include(c => c.Cargo).Include(c => c.Shiptransaction);
            return View(cargoBookings.ToList());
        }
        public ActionResult ViewBooking()
        {
            var cargoBookings = db.CargoBookings.Include(c => c.Cargo).Include(c => c.Shiptransaction);
            return View(cargoBookings.ToList());
        }
        // GET: CargoBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoBooking cargoBooking = db.CargoBookings.Find(id);
            if (cargoBooking == null)
            {
                return HttpNotFound();
            }
            return View(cargoBooking);
        }

        // GET: CargoBookings/Create
        public ActionResult Create()
        {
            ViewBag.CargoId = new SelectList(db.Cargoes, "Id", "CargoName");
            ViewBag.ShipID = new SelectList(db.Shiptransactions, "ShipId", "ShipName");
            return View();
        }

        // POST: CargoBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingId,CargoId,AgentName,ShipID,DepartDate")] CargoBooking cargoBooking)
        {
            if (ModelState.IsValid)
            {
                db.CargoBookings.Add(cargoBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CargoId = new SelectList(db.Cargoes, "Id", "CargoName", cargoBooking.CargoId);
            ViewBag.ShipID = new SelectList(db.Shiptransactions, "ShipId", "ShipName", cargoBooking.ShipID);
            return View(cargoBooking);
        }

        // GET: CargoBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoBooking cargoBooking = db.CargoBookings.Find(id);
            if (cargoBooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.CargoId = new SelectList(db.Cargoes, "Id", "CargoName", cargoBooking.CargoId);
            ViewBag.ShipID = new SelectList(db.Shiptransactions, "ShipId", "ShipName", cargoBooking.ShipID);
            return View(cargoBooking);
        }

        // POST: CargoBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,CargoId,AgentName,ShipID,DepartDate")] CargoBooking cargoBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargoBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CargoId = new SelectList(db.Cargoes, "Id", "CargoName", cargoBooking.CargoId);
            ViewBag.ShipID = new SelectList(db.Shiptransactions, "ShipId", "ShipName", cargoBooking.ShipID);
            return View(cargoBooking);
        }

        // GET: CargoBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoBooking cargoBooking = db.CargoBookings.Find(id);
            if (cargoBooking == null)
            {
                return HttpNotFound();
            }
            return View(cargoBooking);
        }

        // POST: CargoBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CargoBooking cargoBooking = db.CargoBookings.Find(id);
            db.CargoBookings.Remove(cargoBooking);
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
