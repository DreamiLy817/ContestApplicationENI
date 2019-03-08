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

namespace ContestApp.Controllers
{
    public class ResultatsController : Controller
    {
        private ContextContest db = new ContextContest();

        // GET: Result
        public ActionResult Index()
        {
            var resultat = db.Resultat.Include(r => r.Epreuve);
            return View(resultat.ToList());
        }

        // GET: Result/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultat resultat = db.Resultat.Find(id);
            if (resultat == null)
            {
                return HttpNotFound();
            }
            return View(resultat);
        }

        // GET: Result/Create
        public ActionResult Create()
        {
            ViewBag.EpreuveId = new SelectList(db.Epreuves, "Id", "Nom");
            return View();
        }

        // POST: Result/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EpreuveId,Temps,Positionfinale")] Resultat resultat)
        {
            if (ModelState.IsValid)
            {
                db.Resultat.Add(resultat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EpreuveId = new SelectList(db.Epreuves, "Id", "Nom", resultat.EpreuveId);
            return View(resultat);
        }

        // GET: Result/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultat resultat = db.Resultat.Find(id);
            if (resultat == null)
            {
                return HttpNotFound();
            }
            ViewBag.EpreuveId = new SelectList(db.Epreuves, "Id", "Nom", resultat.EpreuveId);
            return View(resultat);
        }

        // POST: Result/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EpreuveId,Temps,Positionfinale")] Resultat resultat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EpreuveId = new SelectList(db.Epreuves, "Id", "Nom", resultat.EpreuveId);
            return View(resultat);
        }

        // GET: Result/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultat resultat = db.Resultat.Find(id);
            if (resultat == null)
            {
                return HttpNotFound();
            }
            return View(resultat);
        }

        // POST: Result/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resultat resultat = db.Resultat.Find(id);
            db.Resultat.Remove(resultat);
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
