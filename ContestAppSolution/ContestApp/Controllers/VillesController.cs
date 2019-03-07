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
using ContestApp.Models;

namespace ContestApp.Controllers
{
    public class VillesController : Controller
    {
        private IRepository<Ville> _repository;

        public VillesController(IRepository<Ville> repository)
        {
            this._repository = repository;
        }

        // GET: Villes
        public ActionResult Index()
        {
            var villes = this._repository.GetAll();
            return View(villes.Select(v=> v.Map<VilleViewModel>()));
        }

        // GET: Villes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ville ville = this._repository.Get(id);
            if (ville == null)
            {
                return HttpNotFound();
            }
            return View(ville.Map<VilleViewModel>());
        }

        // GET: Villes/Create
        public ActionResult Create()
        {
            Ville ville = new Ville();
            return View(ville.Map<VilleViewModel>());
        }

        // POST: Villes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VilleViewModel villeVm)
        {
            if (ModelState.IsValid)
            { 
                try
                {
                    this._repository.Create(villeVm.Map<Ville>());
                    this._repository.Commit();

                    return RedirectToAction(nameof(this.Index));

                } catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                
            }

            return View(villeVm);
        }

        // GET: Villes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ville ville = this._repository.Get(id);
            if (ville == null)
            {
                return HttpNotFound();
            }
            return View(ville.Map<VilleViewModel>());
        }

        // POST: Villes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VilleViewModel villeVm)
        {
            if (!ModelState.IsValid)
            {
                return View(villeVm);
            }

            try
            {
                Ville ville = this._repository.Get(villeVm.Id);
                villeVm.Map(ville);
                this._repository.Commit();

                return RedirectToAction(nameof(this.Index));

            } catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(villeVm);
        }

        // GET: Villes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ville ville= this._repository.Get(id);
            if (ville == null)
            {
                return HttpNotFound();
            }

            return View(ville.Map<VilleViewModel>());
        }

        // POST: Villes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                this._repository.Delete(id);
                this._repository.Commit();

                return RedirectToAction(nameof(this.Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return this.Delete(id);
            }
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
