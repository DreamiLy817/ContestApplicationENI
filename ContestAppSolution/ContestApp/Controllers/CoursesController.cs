using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO.Models;
using ContestApp.Models;
using BO.Repository;
using ContestApp.Extensions;

namespace ContestApp.Controllers
{
    public class CoursesController : Controller
    {
        private IRepository<Course> _repository;

        public CoursesController(IRepository<Course> repository)
        {
            this._repository = repository;
        }

        // GET: Courses
        public ActionResult Index()
        {
            //var epreuve = db.Course.ToList();
            //epreuve.Select(e => Mapper.Map<CourseViewModel>(e))
            var courses = this._repository.GetAll();
            return View(courses.Select(c => c.Map<CourseViewModel>()));
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = this._repository.Get(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Epreuve epreuve = db.Epreuves.Find(id);
            //if (epreuve == null)
            //{
            //    return HttpNotFound();
            //}
            return View(course.Map<CreateEditEpreuveViewModel>());
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            Course course = new Course();
            return View("CreateEdit", course.Map<CreateEditEpreuveViewModel>());
        }


        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Epreuve epreuve = this._repository.Get(id);
            if (epreuve == null)
            {
                return HttpNotFound();
            }

            return View("CreateEdit", epreuve.Map<CreateEditEpreuveViewModel>());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(CreateEditEpreuveViewModel epreuveVm)
        {
            /*
            //on instancie un objetBD à partir du view model récupéré en param
            //si le modelstate est valide
            //on crée une course
            //on redirige à la page index
            //sinon on retourne la view avec le view model de course
            */
            Course course = this._repository.Get(epreuveVm.Id);
            if (ModelState.IsValid)
            {

                if (course == null)
                {
                    course = new Course();
                    this._repository.Create(course);
                }

                epreuveVm.Map(course);

                this._repository.Commit();
                return RedirectToAction(nameof(this.Index));
            }
            return View("CreateEdit", epreuveVm);
        }



        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = this._repository.Get(id);
            if (course == null)
            {
                return HttpNotFound();
            }

            return View(course.Map<CreateEditEpreuveViewModel>());
        }


        // POST: Courses/Delete/5
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
