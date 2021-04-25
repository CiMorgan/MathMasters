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
    public class TutorController : Controller
    {
        [Authorize]
        // GET: Tutor
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TutorService(userId);
            var model = service.GetAllTutors();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTutor model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateTutorService();

            if (service.CreateTutor(model))
            {
                TempData["SaveResult"] = "A tutor was added.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "A tutor could not be added.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateTutorService();
            var model = svc.GetTutorById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTutorService();
            var detail = service.GetTutorById(id);
            var model =
                new EditTutor
                {
                    TutorId = detail.TutorId,
                    TutorFirstName = detail.TutorFirstName,
                    TutorLastName = detail.TutorLastName,
                    TutorCourseList = detail.TutorCourseList
                };
            return View(model);
        }
        private TutorService CreateTutorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TutorService(userId);
            return service;
        }
    }
}