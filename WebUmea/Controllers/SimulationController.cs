using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUmea.Models;

namespace WebUmea.Controllers
{
    public class SimulationController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Simulation
        public ActionResult Index(int id)
        {
            var contributionViewData = from co in context.Contributions
                                       join unc in context.UncertaintyBudgets on co.UbId equals unc.UbId
                                       join pd in context.Pdfs on co.pdfId equals pd.IdNumber
                                       join ins in context.Instruments on unc.InstrumentId equals ins.InstrumentId

                                       join au in context.Authors on unc.AuthorId equals au.AuthorId
                                       where unc.InstrumentId == id
                                       select new DemoObject()
                                       {
                                           coId = co.ContributionId,
                                           coSym =co.Symbol,
                                           coName =co.Name,
                                           coEstimatedValue =co.EstimatedValue,
                                           Distribution = pd.Name,
                                           coStdUnc = co.StandardUncertainty,
                                           coSC = co.SensitivityCoefficient,
                                         
                                           InsName = ins.InstrumentName,
                                           AuName = au.Name
                                       };
            return View(contributionViewData.ToList());
        }

        // POST: Instruments/Create
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateInstrument([Bind(Include = "InstrumentId,InstrumentName,Manufacturer,InstrumentModel,Description")] Instrument instrument)
        {
            if (ModelState.IsValid)
            {
                context.Instruments.Add(instrument);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instrument);
        }

    }
}