using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebUmea.Models;

namespace WebUmea.Controllers
{
    public class DemoController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        //Load List Of registered Instrument
        public ActionResult Index()
        {
            var listOfInstruments = context.Instruments.ToList();

            return View("Index", listOfInstruments);
        }


        //Call Detail Page View of a selected Instrument
        public ActionResult PageView(int id)
        {

            var insQuery = context.Instruments.SingleOrDefault(c => c.InstrumentId == id);

            Instrument instrument = insQuery;

            return View("PageView", insQuery);
        }

        //To Display All Associated Measurement Uncertainty Budgets to an Instrument
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


        //To Register A New Instrument - Add New Instrument
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

        //To Add A New Measurement Uncertainty Budget Table To An Instrument 
        public ActionResult AddNewUncertainty(int id)
        {
            var insQuery = context.Instruments.SingleOrDefault(c => c.InstrumentId == id);


            var addUncertainty = context.UncertaintyBudget.Add(new UncertaintyBudget() { InstrumentId = id, AuthorId = 1, UserId = 1 });

            var addRowToUncertainty = context.Contributions.Add(new Contribution() { UbId = addUncertainty.UbId });
            context.SaveChanges();

            return View("PageView", insQuery);
        }

        //Remove All Uncertainty Budget Table 
        public ActionResult RemoveUncertainty(int id)
        {
            //First Delete Contributions in Contribution Table 
            var removeRowToUncertainty = context.Contributions.Where(co => co.UbId == id).ToList();
            context.Contributions.RemoveRange(removeRowToUncertainty);

            //Next delete Record from Uncertainty Budget Table
            var ubTable = context.UncertaintyBudget.Single(ub => ub.UbId == id);
            context.UncertaintyBudget.Remove(ubTable);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        //Add Row To a Contribution
        public ActionResult AddContribution(int id)
        {
            var AddRow = context.Contributions.Add(new Contribution() { UbId = id });
            context.SaveChanges();

            return RedirectToAction("Index"); 
        }


        // GET: Instruments/Edit/5
        public ActionResult ContributionEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contribution contribution = context.Contributions.Find(id);
            if (contribution == null)
            {
                return HttpNotFound();
            }
            return View(contribution);
        }

        // POST: Instruments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contribution contribution)
        {
            if (ModelState.IsValid)
            {
                context.Entry(contribution).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contribution);
        }
    }
}