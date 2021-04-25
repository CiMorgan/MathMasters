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

        private StudentService CreateStudentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StudentService(userId);
            return service;
        }
    }
}