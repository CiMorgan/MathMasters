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
    [Authorize]
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StudentService(userId);
            var model = service.GetAllStudents();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateStudent model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateStudentService();

            if (service.CreateStudent(model))
            {
                TempData["SaveResult"] = "A student was added.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "A student could not be added.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateStudentService();
            var model = svc.GetStudentById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateStudentService();
            var detail = service.GetStudentById(id);
            var model =
                new EditStudent
                {
                    StudentId = detail.StudentId,
                    StudentFirstName = detail.StudentFirstName,
                    StudentLastName = detail.StudentLastName,
                    StudentGradeLevel = detail.StudentGradeLevel
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditStudent model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.StudentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateStudentService();

            if (service.UpdateStudent(model))
            {
                TempData["SaveResult"] = "The student was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The student could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateStudentService();
            var model = svc.GetStudentById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItem(int id)
        {
            var service = CreateStudentService();

            service.DeleteStudent(id);

            TempData["SaveResult"] = "The student was deleted";

            return RedirectToAction("Index");
        }
        private StudentService CreateStudentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StudentService(userId);
            return service;
        }
    }
}