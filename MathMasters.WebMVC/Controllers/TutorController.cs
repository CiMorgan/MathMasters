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
                    Location = detail.Location
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditTutor model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TutorId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTutorService();

            if (service.UpdateTutor(model))
            {
                TempData["SaveResult"] = "The tutor was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The tutor could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTutorService();
            var model = svc.GetTutorById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItem(int id)
        {
            var service = CreateTutorService();

            service.DeleteTutor(id);

            TempData["SaveResult"] = "The tutor was deleted";

            return RedirectToAction("Index");
        }
        private TutorService CreateTutorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TutorService(userId);
            return service;
        }
    }
}