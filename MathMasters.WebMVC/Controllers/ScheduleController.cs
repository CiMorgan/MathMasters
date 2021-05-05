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
        // GET: Schedule
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
        //Create new schedule at library
        public ActionResult CreateLibrary(CreateSchedule model)
        {
            View();
            var times = GetAllTimes();
            var courses = GetAllCourses();
            var cList = GetCourses(courses);
            var tutors = GetTutorByLocation(ListOfLocations.Library);
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
        //Create new schedule at community center
        public ActionResult CreateCenter(CreateSchedule model)
        {
            View();
            var times = GetAllTimes();
            var courses = GetAllCourses();
            var cList = GetCourses(courses);
            var tutors = GetTutorByLocation(ListOfLocations.CommunityCenter);
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
        //Create new schedule at school
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
        //Get schedule details
        public ActionResult Details(int id)
        {
            var svc = CreateScheduleService();
            var model = svc.GetScheduleById(id);

            return View(model);
        }
        //Update schedule
        public ActionResult Edit(int id)
        {
            var svc = CreateScheduleService();
            var modelOrg = svc.GetScheduleById(id);
            var model = new EditSchedule();
            model.ScheduleId = id;
            var times = GetAllTimes();
            var courses = GetAllCourses();
            var cList = GetCourses(courses);
            var tutors = GetTutorByLocation(modelOrg.LocationSchedule);
            var tList = GetLocationsTutors(tutors);
            model.AvailableDays = TimesSelectListItems(times);
            model.AvailableTutors = LocationTutorListItems(tList);
            model.AvailableCourses = CourseListItems(cList);

            var service = CreateScheduleService();
            var detail = service.GetScheduleById(id);

            model.ScheduleId = id;
            model.ScheduleTutorID = detail.ScheduleTutor;
            model.ScheduleCourseID = detail.ScheduleCourse;
            model.ScheduleDate = detail.TimeSchedule;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditSchedule model)
        {
            View();
            var times = GetAllTimes();
            var courses = GetAllCourses();
            var cList = GetCourses(courses);
            var tutors = GetTutorByLocation(model.ScheduleLocation);
            var tList = GetLocationsTutors(tutors);
            model.ScheduleId = id;
            model.AvailableDays = TimesSelectListItems(times);
            model.AvailableTutors = LocationTutorListItems(tList);
            model.AvailableCourses = CourseListItems(cList);

            if (!ModelState.IsValid) return View(model);

            if (model.ScheduleId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateScheduleService();

            if (service.UpdateSchedule(model))
            {
                TempData["SaveResult"] = "The schedule was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The schedule could not be updated.");
            return View(model);
        }
        //Delete schedule
        public ActionResult Delete(int id)
        {
            var svc = CreateScheduleService();
            var model = svc.GetScheduleById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItem(int id)
        {
            var service = CreateScheduleService();

            service.DeleteSchedule(id);

            TempData["SaveResult"] = "The schedule was deleted";

            return RedirectToAction("Index");
        }
        private ScheduleService CreateScheduleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ScheduleService(userId);
            return service;
        }

        //Below used to create drop down lists for create and update
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