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
using BO.Repository;
using ContestApp.Extensions;

namespace ContestApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class PointOfInterestsController : Controller
    {
        private IRepository<PointOfInterest> _repository;

        private ContextContest db = new ContextContest();

        public PointOfInterestsController(IRepository<PointOfInterest> repository)
        {
            this._repository = repository;
        }

        // GET: PointOfInterests
        public ActionResult Index()
        {
            return View(db.PointOfInterest.Include(p => p.Categorie).Include(po => po.Epreuve).ToList());
        }

        // GET: PointOfInterests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointOfInterest pointOfInterest = db.PointOfInterest.Include(p => p.Categorie).Include(po => po.Epreuve).Where(poi => poi.Id == id).FirstOrDefault();
            if (pointOfInterest == null)
            {
                return HttpNotFound();
            }
            return View(pointOfInterest);
        }

        // GET: PointOfInterests/Create
        public ActionResult Create()
        {
            return View("CreateEdit",Mapper.Map<PointOfInterestViewModel>(new PointOfInterest()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(PointOfInterestViewModel pointOfInterest)
        {

            PointOfInterest poi = this._repository.Get(pointOfInterest.Id);

            if (ModelState.IsValid || true)
            {

                if (poi == null)
                {
                    poi = new PointOfInterest();
                    this._repository.Create(poi);
                }

                pointOfInterest.Map(poi);

                this._repository.Commit();
                return RedirectToAction(nameof(this.Index));
            }
            return View("CreateEdit", pointOfInterest);
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
            return View("CreateEdit", Mapper.Map<PointOfInterestViewModel>(pointOfInterest));
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
