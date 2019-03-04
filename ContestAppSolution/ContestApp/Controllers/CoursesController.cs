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
using ContestApp.App_Start;

namespace ContestApp.Controllers
{
    public class CoursesController : Controller
    {
        private ContextContest db = new ContextContest();

        // GET: Courses
        public ActionResult Index()
        {
            var epreuve = db.Course.ToList();
            return View(epreuve.Select(e => Mapper.Map<CourseViewModel>(e)));
        }

        // GET: Courses/Details/5
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

        // GET: Courses/Create
        public ActionResult Create()
        {
            Epreuve epreuve = new Course();
            return View("CreateEdit", Mapper.Map<CourseViewModel>(epreuve));
        }


        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Epreuve epreuve = db.Course.Find(id);
            if (epreuve == null)
            {
                return HttpNotFound();
            }
            //passer un vm
            return View("CreateEdit", epreuve);
        }
      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(CourseViewModel epreuveVM)
        {
            Course epreuve = db.Course.Find(epreuveVM.Id);
            if(epreuve == null)
            {
                epreuve = new Course();
                db.Course.Add(epreuve);
            }

            Mapper.Map(epreuveVM, epreuve);

            if (ModelState.IsValid)
            {

                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View("CreateEdit", epreuveVM);
        }
        // GET: Courses/Delete/5
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


        // POST: Courses/Delete/5
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
