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
        public ActionResult CreateLibrary(CreateSchedule model)
        {
            View();
            var times = GetAllTimes();
            var courses = GetAllCourses();
            var cList = GetCourses(courses);
            var tutors = GetTutorByLocation(ListOfLocations.School);
            var tList = GetLocationsTutors(tutors);
            model.AvailableDays = TimesSelectListItems(times);
            model.AvailableTutors = LocationTutorListItems(tList);
            model.AvailableCourses = CourseListItems(cList);
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
            var courses = GetAllCourses();
            var cList = GetCourses(courses);
            var tutors = GetTutorByLocation(ListOfLocations.School);
            var tList = GetLocationsTutors(tutors);
            model.AvailableDays = TimesSelectListItems(times);
            model.AvailableTutors = LocationTutorListItems(tList);
            model.AvailableCourses = CourseListItems(cList);
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
            var courses = GetAllCourses();
            var cList = GetCourses(courses);
            var tutors = GetTutorByLocation(ListOfLocations.School);
            var tList = GetLocationsTutors(tutors);
            model.AvailableDays = TimesSelectListItems(times);
            model.AvailableTutors = LocationTutorListItems(tList);
            model.AvailableCourses = CourseListItems(cList);
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
        public ActionResult Details(int id)
        {
            var svc = CreateScheduleService();
            var model = svc.GetScheduleById(id);

            return View(model);
        }

        private ScheduleService CreateScheduleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ScheduleService(userId);
            return service;
        }

        //Below used to create drop down lists for create 
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
        public List<Course> GetAllCourses()
        {
            var cList = new List<Course>();
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses;
                        {
                            foreach (Course course in entity)
                            {
                                cList.Add(course);
                            }
                        }
                        return cList;
            }
        }
        private IEnumerable<string> GetCourses(List<Course> AvailableCourse)
        {
            var cList = new List<string>();
            foreach (var course in AvailableCourse)
            {
                cList.Add(course.Id + "-" + course.Name);
            }
            return cList;
        }
        private IEnumerable<SelectListItem> CourseListItems(IEnumerable<string> AvailableCourse)
        {
            var courseList = new List<SelectListItem>();
            foreach (var course in AvailableCourse)
            {
                courseList.Add(new SelectListItem
                {
                    Value = course,
                    Text = course
                });
            }
            return courseList;
        }
    }
}