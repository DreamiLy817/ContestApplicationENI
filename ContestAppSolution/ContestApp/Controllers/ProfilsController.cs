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


namespace ContestApp.Controllers
{
    
    public class ProfilsController : Controller
    {
        private IRepository<Profil> _repository;
        private ContextContest db = new ContextContest();

        public ProfilsController(IRepository<Profil> repository)
        {
            this._repository = repository;
        }

        // GET: Profils
        public ActionResult Index()
        {   
            return View(db.Profil.ToList());
        }

        // GET: Profils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profil profil = db.Profil.Find(id);
            if (profil == null)
            {
                return HttpNotFound();
            }
            return View(profil);
        }

        // GET: Profils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profils/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom")] Profil profil)
        {
            if (ModelState.IsValid)
            {
                db.Profil.Add(profil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profil);
        }

        // GET: Profils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profil profil = db.Profil.Find(id);
            if (profil == null)
            {
                return HttpNotFound();
            }
            return View(profil);
        }

        // POST: Profils/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom")] Profil profil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profil);
        }

        // GET: Profils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profil profil = db.Profil.Find(id);
            if (profil == null)
            {
                return HttpNotFound();
            }
            return View(profil);
        }

        // POST: Profils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profil profil = db.Profil.Find(id);
            db.Profil.Remove(profil);
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
