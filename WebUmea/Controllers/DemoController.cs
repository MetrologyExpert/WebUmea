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
                         where (co.UbId == 10)
                         select new DemoObject() {

                             UbId = ub.UbId,
                             ContributionIds = co.ContributionId,
                             ContributionName = co.Name,
                             ContributionEstimatedValue = co.EstimatedValue,
                             ContributionSensitivityCoefficient = co.SensitivityCoefficient,
                             StandardUncertainty = co.StandardUncertainty


                         };

            //Query with all information to display
            //var queryUb = from ub in context.UncertaintyBudget
            //              join co in context.Contributions on ub.UbId equals co.UbId
            //              join i in context.Instruments on ub.InstrumentId equals i.InstrumentId
            //              join a in context.Authors on ub.AuthorId equals a.AuthorId
            //              join p in context.Pdfs on co.PdfId equals p.Id
            //              where (co.UbId == 10)

                     //              select new Demoobject()
                     //              {
                     //                  ubId = ub.UbId,
                     //                  aAuthor = ub.Author.Name,
                     //                  iInstrument = ub.Instrument.InstrumentName,
                     //                  iManufacturer = ub.Instrument.Manufacturer,
                     //                  iModel = ub.Instrument.InstrumentModel,
                     //                  cContributionId = co.ContributionId,
                     //                  cSymbol = co.Symbol,
                     //                  Name = co.Name,
                     //                  cEstimatedValues = co.EstimatedValue,
                     //                  cPdfId = co.PdfId,
                     //                  cSensCoeff = co.SensitivityCoefficient,
                     //                  cSU = co.StandardUncertainty
                     //              };

            return View(queryUb);
        }
    }
}