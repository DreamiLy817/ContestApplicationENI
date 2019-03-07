using BO.Models;
using ContestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContestApp.Extensions;
using BO.Repository;
using System.Net;

namespace ContestApp.Controllers
{
    public class DisplayConfigurationController : Controller
    {
        private IRepository<DisplayConfiguration> _repository;

        public DisplayConfigurationController(IRepository<DisplayConfiguration> repository)
        {
            this._repository = repository;
        }

        // GET: DisplayConfiguration
        public ActionResult Index()
        {
            var displayConfig = this._repository.GetAll();

            return View(displayConfig.Select(dc => dc.Map<DisplayConfigurationViewModel>()));
        }

        // GET: DisplayConfiguration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DisplayConfiguration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisplayConfiguration/Create
        [HttpPost]
        public ActionResult Create(DisplayConfigurationViewModel displayConfigVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this._repository.Create(displayConfigVm.Map<DisplayConfiguration>());
                    this._repository.Commit();

                    return RedirectToAction(nameof(this.Index));

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message );
                   
                }
            }

            return View(displayConfigVm);
        }

        // GET: DisplayConfiguration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DisplayConfiguration displayConfig = this._repository.Get(id);
            if (displayConfig == null)
            {
                return HttpNotFound();
            }
            return View(displayConfig.Map<DisplayConfigurationViewModel>());
        }

        // POST: DisplayConfiguration/Edit/5
        [HttpPost]
        public ActionResult Edit(DisplayConfigurationViewModel displayConfigVm)
        {
            if (!ModelState.IsValid)
            {
                return View(displayConfigVm);
            }
            try
            {
                DisplayConfiguration disConfig = this._repository.Get(displayConfigVm.Id);
                displayConfigVm.Map(disConfig);

                this._repository.Commit();

                return RedirectToAction(nameof(this.Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(displayConfigVm);
            
        }

        // GET: DisplayConfiguration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DisplayConfiguration/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
