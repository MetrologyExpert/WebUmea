using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebUmea.Models;

namespace WebUmea.Controllers
{
    public class DemoController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Index()
        {
            var insQuery = context.Instruments.ToList();

           

            return View("Index", insQuery);

        }


        public ActionResult InstrumentView()
        {
            var instrumentViewData = from co in context.Contributions
                                     group co by co.UbId into groupco
                                     select new DemoGroup<int, Contribution> { Key = groupco.Key, Values = groupco };

            return PartialView("~/Views/Instruments/_InstrumentBox.cshtml", instrumentViewData.ToList());
        }
    }
}