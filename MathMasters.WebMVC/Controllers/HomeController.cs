using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MathMasters.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is a fake application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Please do not contact for math assistance since this is a fake application.";

            return View();
        }
    }
}