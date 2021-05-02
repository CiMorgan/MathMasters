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

        public ActionResult Location()
        {
            return View();
        }

        //public ActionResult CreateLibrary(CreateSchedule model)
        //{
        //    var tutors = GetTutorByLocation(ListOfLocations.School);
        //    View();
        //    return Create(tutors, model);
        //}
        //public ActionResult CreateCenter(CreateSchedule model)
        //{
        //    var tutors = GetTutorByLocation(ListOfLocations.CommunityCenter);
        //    View();
        //    return Create(tutors, model);
        //}
        //public ActionResult CreateSchool(CreateSchedule model)
        //{
        //    var tutors = GetTutorByLocation(ListOfLocations.School);
        //    View();
        //    return Create(tutors, model);
        //}

        //public ActionResult CreateLibrary()
        //{
        //    return View();
        //}
        //public ActionResult CreateLibrary()
        //{

        //}

        public ActionResult CreateLibrary(CreateSchedule model)
        {
            View();
            var times = GetAllTimes();
            var tutors = GetTutorByLocation(ListOfLocations.Library);
            var tList = GetLocationsTutors(tutors);
            model.AvailableDays = TimesSelectListItems(times);
            model.AvailableTutors = LocationTutorListItems(tList);
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

        public ActionResult CreateCenter(CreateSchedule model)
        {
            View();
            var times = GetAllTimes();
            var tutors = GetTutorByLocation(ListOfLocations.CommunityCenter);
            var tList = GetLocationsTutors(tutors);
            model.AvailableDays = TimesSelectListItems(times);
            model.AvailableTutors = LocationTutorListItems(tList);
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

        public ActionResult CreateSchool(CreateSchedule model)
        {
            View();
            var times = GetAllTimes();
            var tutors = GetTutorByLocation(ListOfLocations.School);
            var tList = GetLocationsTutors(tutors);
            model.AvailableDays = TimesSelectListItems(times);
            model.AvailableTutors = LocationTutorListItems(tList);
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

        [HttpPost]
        [ValidateAntiForgeryToken]

        //public ActionResult Create(ListOfLocations location, CreateSchedule model)
        //{
        //    var times = GetAllTimes();
        //    var tutors = GetTutorByLocation(location);
        //    var tList = GetLocationsTutors(tutors);
        //    model.AvailableDays = TimesSelectListItems(times);
        //    model.AvailableTutors = LocationTutorListItems(tList);
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    var service = CreateScheduleService();

        //    if (service.CreateSchedule(model))
        //    {
        //        TempData["SaveResult"] = "A new schedule was added.";
        //        return RedirectToAction("Index");
        //    }
        //    ModelState.AddModelError("", "A schedule could not be added.");
        //    return View(model);
        //}
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
                "Monday at 3:00",
                "Monday at 5:00",
                "Wednesday at 3:00",
                "Wednesday at 5:00",
                "Saturday at 1:00",
                "Saturday at 3:00"
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
        public List<Tutor> GetTutorByLocation(ListOfLocations location)
        {
            var tList = new List<Tutor>();
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tutors
                        .Where(e => e.Location == location);

                foreach (Tutor tutor in entity)
                {
                    tList.Add(tutor);
                }
                return tList;
            }
        }
        private IEnumerable<string> GetLocationsTutors(List<Tutor> locationTutors)
        {
            var tList = new List<string>();
            foreach (var tutor in locationTutors)
            {
                tList.Add(tutor.Id+"-"+tutor.LastName + ", " + tutor.FirstName);
            }
            return tList;
        }
        private IEnumerable<SelectListItem> LocationTutorListItems(IEnumerable<string> localTutors)
        {
            var tutorList = new List<SelectListItem>();
            foreach (var tutor in localTutors)
            {
                tutorList.Add(new SelectListItem
                {
                    Value = tutor,
                    Text = tutor
                });
            }
            return tutorList;
        }
    }
}