using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUmea.Controllers
{
    public class MainController : Controller
    {
        // GET: /Main/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            return View("Contactus");
        }

        [HttpGet]
        public ActionResult Contactus()
        {
            return View();
        }
    }
}