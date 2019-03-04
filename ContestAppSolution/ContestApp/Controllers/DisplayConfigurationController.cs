using ContestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContestApp.Controllers
{
    public class DisplayConfigurationController : Controller
    {


        // GET: DisplayConfiguration
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: DisplayConfiguration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DisplayConfiguration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
