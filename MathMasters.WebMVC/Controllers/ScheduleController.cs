using MathMasters.Data;
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
    public class ScheduleController : Controller
    {
        [Authorize]
        // GET: Tutor
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ScheduleService(userId);
            var model = service.GetAllSchedules();
            return View(model);
        }

        public ActionResult CreateGetLocation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<Tutor> tutorList, CreateSchedule model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateScheduleService();

            if (service.CreateSchedule(tutorList, model))
            {
                TempData["SaveResult"] = "A new schedule was added.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "A schedule could not be added.");
            return View(model);
        }
        private ScheduleService CreateScheduleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ScheduleService(userId);
            return service;
        }
    }
}