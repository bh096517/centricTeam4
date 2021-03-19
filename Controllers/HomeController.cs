using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace centricTeam4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Employee recognition is very important at Centric Consulting, so nominate a co-worker for their exemplary performance or reinforce particular behaviors, practices, or activities that result in better performance.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Centric Consulting Contact Page";

            return View();
        }
    }
}