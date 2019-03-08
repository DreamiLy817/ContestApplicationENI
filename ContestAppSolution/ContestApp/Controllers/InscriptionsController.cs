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
using ContestApp.Models;
using ContestApp.Extensions;

namespace ContestApp.Controllers
{
    public class InscriptionsController : Controller
    {
        private IRepository<Inscription> _repository;
        public InscriptionsController(IRepository<Inscription> repository)
        {
            this._repository = repository;
        }

        // GET: Inscriptions
        public ActionResult Index()
        {
         
            var inscription = this._repository.GetAll();
            if(!User.IsInRole("Administrator"))
            {
                inscription = inscription.Where(i => i.UtilisateurName == User.Identity.Name).ToList();
            }
            return View(inscription);
        }


        // GET: Inscriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscription inscription = this._repository.Get(id);
            if (inscription == null)
            {
                return HttpNotFound();
            }
         
            return View(inscription.Map<InscriptionViewModel>());
        }

        // GET: Inscriptions/Create
        public ActionResult Create()
        {
            Inscription inscription = new Inscription();
            return View("CreateEdit", inscription.Map<InscriptionViewModel>());
        }


        // GET: Inscriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscription inscription = this._repository.Get(id);
            if (inscription == null)
            {
                return HttpNotFound();
            }

            return View("CreateEdit", inscription.Map<InscriptionViewModel>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(InscriptionViewModel inscriptionVm)
        {
            /*
            //on instancie un objetBD à partir du view model récupéré en param
            //si le modelstate est valide
            //on crée une course
            //on redirige à la page index
            //sinon on retourne la view avec le view model de course
            */
            Inscription inscription = this._repository.Get(inscriptionVm.Id);
            if (ModelState.IsValid)
            {

                if (inscription == null)
                {
                    inscription = new Inscription();
                    this._repository.Create(inscription);
                }

                inscriptionVm.Map(inscription);
                inscription.dateInscription = DateTime.Now;
                inscription.UtilisateurName = User.Identity.Name;

                this._repository.Commit();
                return RedirectToAction(nameof(this.Index));
            }
            return View("CreateEdit", inscriptionVm);
        }


        // GET: Inscriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscription inscription = this._repository.Get(id);
            if (inscription == null)
            {
                return HttpNotFound();
            }

            return View(inscription);
        }


        // POST: Inscriptions/Delete/5
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
                // this._repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
