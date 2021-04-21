using MathMasters.Models;
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
            var model = new AllCourseList[0];
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}