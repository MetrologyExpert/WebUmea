using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUmea.Models;

namespace WebUmea.Controllers
{
    public class DemoController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Demo
        public ActionResult Index()
        {
            var queryUb = from ub in context.UncertaintyBudget
                         join co in context.Contributions on ub.UbId equals co.UbId
                         join ins in context.Instruments on ub.InstrumentId equals ins.InstrumentId
                         where (co.UbId == 10 )
                         select new DemoObject() {

                             UbId = ub.UbId,
                             ContributionIds = co.ContributionId,
                             ContributionName = co.Name,
                             ContributionEstimatedValue = co.EstimatedValue,
                             ContributionSensitivityCoefficient = co.SensitivityCoefficient,
                             StandardUncertainty = co.StandardUncertainty,
                             InstrumentId = ins.InstrumentId,
                             InstrumentName = ins.InstrumentName
                         };

            return View(queryUb);
        }


        public ActionResult InstrumentView()
        {
            var queryInstrument = from ins in context.Instruments
                                  select new DemoObject() {
                                      InstrumentId = ins.InstrumentId,
                                      InstrumentName = ins.InstrumentName
                                  };

            return PartialView("~/Views/Instruments/_InstrumentBox.cshtml", queryInstrument);
        }
    }
}