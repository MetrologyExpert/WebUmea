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
            var listOfInstruments = context.Instruments.ToList();

            return View("Index", listOfInstruments);
        }



        public ActionResult PageView(int id)
        {

            var insQuery = context.Instruments.SingleOrDefault(c => c.InstrumentId == id);

            Instrument instrument = insQuery;

            return View("PageView", insQuery);
        }

        public ActionResult InstrumentView(int id)
        {
            var contributionViewData = from co in context.Contributions
                                     join unc in context.UncertaintyBudget
                                     on co.UbId equals unc.UbId
                                     where unc.InstrumentId == id
                                     group co by co.UbId into groupco
                                     select new DemoGroup<int, Contribution> { Key = groupco.Key, Values = groupco };

            return PartialView("~/Views/Instruments/_InstrumentBox.cshtml", contributionViewData.ToList());
        }

        // GET: Instruments/Create
        public ActionResult CreateInstrument()
        {
            return View();
        }

        // POST: Instruments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
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

    
        public ActionResult AddNewUncertainty(int id)
        {
            var insQuery = context.Instruments.SingleOrDefault(c => c.InstrumentId == id);

            
           var addUncertainty = context.UncertaintyBudget.Add(new UncertaintyBudget() { InstrumentId = id, AuthorId = 1, UserId = 1 });

            var addRowToUncertainty = context.Contributions.Add(new Contribution() { UbId = addUncertainty.UbId });
            context.SaveChanges();

            return View("PageView", insQuery);
        }
    }
}