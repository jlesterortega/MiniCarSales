using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiniCarSales.DAL;
using MiniCarSales.Models;

namespace MiniCarSales.Controllers
{
    public class VehicleController : Controller
    {
        private VehicleContext db = new VehicleContext();

        // GET: Vehicle
        public ActionResult Index()
        {
            return View(db.Vehicles.ToList());
        }

        // GET: Vehicle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            // create viewbag for body type dropdown
            ViewBag.BodyType = new SelectList(
                    new List<SelectListItem>
                    {
                        new SelectListItem { Selected = false, Text = "Hatch", Value = "Hatch"},
                        new SelectListItem { Selected = false, Text = "Sedan", Value = "Sedan"},
                        new SelectListItem { Selected = false, Text = "SUV", Value = "SUV"},
                        new SelectListItem { Selected = false, Text = "Ute", Value = "Ute"},
                        new SelectListItem { Selected = false, Text = "Wagon", Value = "Wagon"},
                    }, "Value", "Text", 1);
            // create viewbag for make dropdown
            ViewBag.Make = new SelectList(
                    new List<SelectListItem>
                    {
                        new SelectListItem { Selected = false, Text = "Toyota", Value = "Toyota"},
                        new SelectListItem { Selected = false, Text = "Honda", Value = "Honda"},
                        new SelectListItem { Selected = false, Text = "Kia", Value = "Kia"},
                        new SelectListItem { Selected = false, Text = "Hyundai", Value = "Hyundai"},
                        new SelectListItem { Selected = false, Text = "Holden", Value = "Holden"},
                    }, "Value", "Text", 1);
            return View();
        }

        // POST: Vehicle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleID,VehicleType,Make,Model,Engine,Doors,Wheels,SelectedBodyType")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();                            
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: Vehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            // create viewbag for body type dropdown
            ViewBag.BodyType = new SelectList(
                    new List<SelectListItem>
                    {
                        new SelectListItem { Selected = false, Text = "Hatch", Value = "Hatch"},
                        new SelectListItem { Selected = false, Text = "Sedan", Value = "Sedan"},
                        new SelectListItem { Selected = false, Text = "SUV", Value = "SUV"},
                        new SelectListItem { Selected = false, Text = "Ute", Value = "Ute"},
                        new SelectListItem { Selected = false, Text = "Wagon", Value = "Wagon"},
                    }, "Value", "Text", 1);
            // create viewbag for make dropdown
            ViewBag.Make = new SelectList(
                    new List<SelectListItem>
                    {
                        new SelectListItem { Selected = false, Text = "Toyota", Value = "Toyota"},
                        new SelectListItem { Selected = false, Text = "Honda", Value = "Honda"},
                        new SelectListItem { Selected = false, Text = "Kia", Value = "Kia"},
                        new SelectListItem { Selected = false, Text = "Hyundai", Value = "Hyundai"},
                        new SelectListItem { Selected = false, Text = "Holden", Value = "Holden"},
                    }, "Value", "Text", 1);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleID,VehicleType,Make,Model,Engine,Doors,Wheels,SelectedBodyType")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
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
