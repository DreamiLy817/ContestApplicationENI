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
using ContestApp.App_Start;

namespace ContestApp.Controllers
{
    public class EpreuvesController : Controller
    {
        private ContextContest db = new ContextContest();

        // GET: Epreuves
        public ActionResult Index()
        {
            List<Epreuve> epreuve = db.Epreuves.ToList();

            EpreuveViewModel epreuvevm = new EpreuveViewModel();
            return View(epreuve.Select(e => MapperConfig.ReferenceEquals(epreuve, epreuvevm))
            );
        }

        // GET: Epreuves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Epreuve epreuve = db.Epreuves.Find(id);
            if (epreuve == null)
            {
                return HttpNotFound();
            }
            return View(epreuve);
        }

        // GET: Epreuves/Create
        public ActionResult Create()
        {
            return View();
        }

      
        // GET: Epreuves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Epreuve epreuve = db.Epreuves.Find(id);
            if (epreuve == null)
            {
                return HttpNotFound();
            }
            return View(epreuve);
        }

        // POST: Epreuves/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Distance,Date,Inscription")] Epreuve epreuve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(epreuve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(epreuve);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit([Bind(Include = "Id,Nom,Distance,Date,Inscription")] EpreuveViewModel epreuveVM)
        {
            Epreuve epreuve = db.Epreuves.Find(epreuveVM.Id);

            MapperConfig.ReferenceEquals(epreuve, epreuveVM);

            if (ModelState.IsValid)
            {

                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View("CreateEdit", epreuve);
        }

        // GET: Epreuves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Epreuve epreuve = db.Epreuves.Find(id);
            if (epreuve == null)
            {
                return HttpNotFound();
            }
            return View(epreuve);
        }

        // POST: Epreuves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Epreuve epreuve = db.Epreuves.Find(id);
            db.Epreuves.Remove(epreuve);
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
