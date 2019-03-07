using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using BO.Models;
using ContestApp.Models;
using AutoMapper;

namespace ContestApp.Controllers
{
    public class PointOfInterestsController : Controller
    {
        private ContextContest db = new ContextContest();

        // GET: PointOfInterests
        public ActionResult Index()
        {
            return View(db.PointOfInterest.ToList());
        }

        // GET: PointOfInterests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointOfInterest pointOfInterest = db.PointOfInterest.Find(id);
            if (pointOfInterest == null)
            {
                return HttpNotFound();
            }
            return View(pointOfInterest);
        }

        // GET: PointOfInterests/Create
        public ActionResult Create()
        {
            return View(Mapper.Map<PointOfInterestViewModel>(new PointOfInterest()));
        }

        // POST: PointOfInterests/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Distance")] PointOfInterest pointOfInterest)
        {
            if (ModelState.IsValid)
            {
                db.PointOfInterest.Add(pointOfInterest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pointOfInterest);
        }

        // GET: PointOfInterests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointOfInterest pointOfInterest = db.PointOfInterest.Find(id);
            if (pointOfInterest == null)
            {
                return HttpNotFound();
            }
            return View(pointOfInterest);
        }

        // POST: PointOfInterests/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Distance")] PointOfInterest pointOfInterest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pointOfInterest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pointOfInterest);
        }

        // GET: PointOfInterests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointOfInterest pointOfInterest = db.PointOfInterest.Find(id);
            if (pointOfInterest == null)
            {
                return HttpNotFound();
            }
            return View(pointOfInterest);
        }

        // POST: PointOfInterests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PointOfInterest pointOfInterest = db.PointOfInterest.Find(id);
            db.PointOfInterest.Remove(pointOfInterest);
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
