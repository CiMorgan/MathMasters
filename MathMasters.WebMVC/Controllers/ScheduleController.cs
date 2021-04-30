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

        //public ActionResult SelectTimes()
        //{
        //    List<SelectListItem> availableTimes = new List<SelectListItem>();
        //    availableTimes.Add(new SelectListItem { Text = "Monday at 3:30", Value = "0" });
        //    availableTimes.Add(new SelectListItem { Text = "Monday at 5:30", Value = "1" });
        //    availableTimes.Add(new SelectListItem { Text = "Wednesday at 3:30", Value = "2" });
        //    availableTimes.Add(new SelectListItem { Text = "Wednesday at 5:30", Value = "3" });
        //    availableTimes.Add(new SelectListItem { Text = "Saturday at 11:00", Value = "4" });
        //    availableTimes.Add(new SelectListItem { Text = "Saturday at 1:00", Value = "5" });
        //    ViewBag.Create = availableTimes;
        //    return View();
        //}
        public ActionResult Create()
        {
            var times = GetAllTimes();
            var model = new CreateSchedule();
            model.AvailableDays = TimesSelectListItems(times);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSchedule model)
        {
            var times = GetAllTimes();
            model.AvailableDays = TimesSelectListItems(times);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateScheduleService();

            if (service.CreateSchedule(model))
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
        private IEnumerable<string> GetAllTimes()
        {
            return new List<string>
            {
                "Monday at 3:30",
                "Monday at 5:30",
                "Wednesday at 3:30",
                "Wednesday at 5:30",
                "Saturday at 11:00",
                "Saturday at 1:00"
            };
        }
        private IEnumerable<SelectListItem> TimesSelectListItems(IEnumerable<string> times)
        {
            var timesList = new List<SelectListItem>();
            foreach (var timeSlot in times)
            {
                timesList.Add(new SelectListItem
                {
                    Value = timeSlot,
                    Text = timeSlot
                });
            }
            return timesList;
        }
    }
}