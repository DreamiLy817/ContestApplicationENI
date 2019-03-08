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
using BO.Repository;
using ContestApp.Extensions;
using Unity;
using ContestApp.Models;

namespace ContestApp.Controllers
{
    public class ResultatsController : Controller
    {
        private RepositoryResultat _repository;
        private ContextContest db = new ContextContest();

        public ResultatsController(RepositoryResultat repository)
        {
            this._repository = repository;
        }

        // GET: Resultats
        public ActionResult Index()
        {

           
            //var resultat = db.Resultat.Include(r => r.Epreuve).Include(r => r.Profil);
            return View(this._repository.GetAll().Select(r => r.Map<ResultatViewModel>()));
        }

        // GET: Resultats/Details/5
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

        // GET: Resultats/Create
        public ActionResult Create()
        {
            ViewBag.EpreuveId = new SelectList(db.Epreuves, "Id", "Nom");
            ViewBag.ProfilId = new SelectList(db.Profil, "Id", "Nom");
            return View();
        }

        // POST: Resultats/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProfilId,EpreuveId,Temps,Positionfinale")] Resultat resultat)
        {
            if (ModelState.IsValid)
            {
                db.Resultat.Add(resultat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EpreuveId = new SelectList(db.Epreuves, "Id", "Nom", resultat.EpreuveId);
            ViewBag.ProfilId = new SelectList(db.Profil, "Id", "Nom", resultat.ProfilId);
            return View(resultat);
        }

        // GET: Resultats/Edit/5
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
            ViewBag.ProfilId = new SelectList(db.Profil, "Id", "Nom", resultat.ProfilId);
            return View(resultat);
        }

        // POST: Resultats/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProfilId,EpreuveId,Temps,Positionfinale")] Resultat resultat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EpreuveId = new SelectList(db.Epreuves, "Id", "Nom", resultat.EpreuveId);
            ViewBag.ProfilId = new SelectList(db.Profil, "Id", "Nom", resultat.ProfilId);
            return View(resultat);
        }

        // GET: Resultats/Delete/5
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

        // POST: Resultats/Delete/5
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
                //this._repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
