using MathMasters.Models;
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
            var model = new AllScheduleList[0];
            return View(model);
        }
    }
}