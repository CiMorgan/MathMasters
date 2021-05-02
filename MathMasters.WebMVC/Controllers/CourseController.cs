using MathMasters.Models;
using MathMasters.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MathMasters.WebMVC.Controllers
{
    public class CourseController : Controller
    {
        [Authorize]
        // GET: Course
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourseService(userId);
            var model = service.GetAllCourses();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Create(CreateCourse model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateCourseService();

            if (service.CreateCourse(model))
            {
                TempData["SaveResult"] = "A course was added.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "A course could not be added.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateCourseService();
            var model = svc.GetCourseById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateCourseService();
            var detail = service.GetCourseById(id);
            var model =
                new EditCourse
                {
                    CourseId = detail.CourseId,
                    CourseName = detail.CourseName,
                    CourseDescription = detail.CourseDescription
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditCourse model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CourseId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCourseService();

            if (service.UpdateCourse(model))
            {
                TempData["SaveResult"] = "Your course was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your course could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCourseService();
            var model = svc.GetCourseById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItem(int id)
        {
            var service = CreateCourseService();

            service.DeleteCourse(id);

            TempData["SaveResult"] = "The course was deleted";

            return RedirectToAction("Index");
        }

        private CourseService CreateCourseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourseService(userId);
            return service;
        }
    }
}