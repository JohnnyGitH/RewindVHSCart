using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RewindVHSDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Delivery()
        {
            ViewBag.Message = "Delivery Information";

            return View();
        }

        public ActionResult Return()
        {
            ViewBag.Message = "Return Information";

            return View();
        }
    }
}