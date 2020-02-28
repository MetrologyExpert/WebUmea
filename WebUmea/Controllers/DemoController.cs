using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using WebUmea.Models;
using WebUmea.ViewModel;

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
                                       //(when I add pdfs I cant see results)
                                      join unc in context.UncertaintyBudgets on co.UbId equals unc.UbId
                                      join p in context.Pdfs on co.pdfId equals p.IdNumber
                                       where unc.InstrumentId == id
                                      group co by co.UbId into groupco
                                      select new DemoGroup<int, Contribution> { Key = groupco.Key, Values = groupco };




            //var contributionViewData = from co in context.Contributions
            //                           //(when I add pdfs I cant see results)
            //                           join unc in context.UncertaintyBudgets on co.UbId equals unc.UbId
            //                           where unc.InstrumentId == id
            //                           group co by co.UbId into groupco
            //                           select new DemoGroup<int, Contribution> { Key = groupco.Key, Values = groupco };

            //Direct pass via ViewModel - bind with _instrumentBoxY

            //var contributionViewData = from co in context.Contributions
            //                      join ub in context.UncertaintyBudgets on co.UbId equals ub.UbId
            //                      join ins in context.Instruments on ub.InstrumentId equals ins.InstrumentId
            //                      join p in context.Pdfs on co.pdfId equals p.IdNumber
            //                      select new InstrumentUncBudgetViewModel()
            //                      {
            //                          ConId = co.ContributionId,
            //                          QuantityName = co.Name,
            //                          StdUnc = co.StandardUncertainty,
            //                          PdfName = p.Name,
            //                          InsName = ins.InstrumentName,
            //                          UbId = co.UbId
            //                      };

            //select new DemoObject() { UbIds = co.UncertaintyBudget.UbId, PdfName = p.Name };
            //join unc in context.UncertaintyBudgets on co.UbId equals unc.UbId
            //where unc.InstrumentId == id
            //group co by co.UbId into groupco
            //select new DemoGroup< int, Contribution> { Key = groupco.Key, Values = groupco };

            //var contributionViewData = context.Contributions.Join(context.UncertaintyBudgets, 
            //    co => co.UbId, 
            //    un => un.UbId, 
            //    (co,un) => new DemoObject{  ContributionIds = co.ContributionId,
            //                      InsId = un.InstrumentId }).ToList();

            //var contributionViewData = context.Contributions.Join(context.UncertaintyBudgets, unc => unc.UbId, co => co.UbId, (co, unc) => new { co, unc }).
            //                                                 Join(context.Pdfs, p => p.co.pdfId, pd => pd.IdNumber, (p, pd) => new { p, pd }).
            //                                                 Where(u => u.p.unc.InstrumentId == id).
            //                                                 GroupBy(c => c.p.unc.UbId).ToList();

            //**************With each LINQ Query is there a problem of threading 

            return PartialView("~/Views/Demo/_InstrumentBox.cshtml", contributionViewData.ToList());
        }

        
        // To Register A New Instrument - Add New Instrument
        public ActionResult CreateInstrument()
        {
            return View();
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

        // GET: Instruments/Edit/5
        public ActionResult EditInstrument(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrument instrument = context.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            return View(instrument);
        }

        // POST: Instruments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInstrument([Bind(Include = "InstrumentId,InstrumentName,Manufacturer,InstrumentModel,Description,UncertaintyId")] Instrument instrument)
        {
            if (ModelState.IsValid)
            {
                context.Entry(instrument).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instrument);
        }

            // GET: Instruments/Delete/5
            public ActionResult DeleteInstrument(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrument instrument = context.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            return View(instrument);
        }

        // POST: Instruments/Delete/5
        [HttpPost, ActionName("DeleteInstrument")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteInstrumentConfirmed(int id)

        {   var delContribution = context.Contributions.Where(c => c.UncertaintyBudget.InstrumentId == id).ToList();
            context.Contributions.RemoveRange(delContribution);

            var delUnc = context.UncertaintyBudgets.Where(u => u.InstrumentId == id).ToList();
            context.UncertaintyBudgets.RemoveRange(delUnc);

            Instrument instrument = context.Instruments.Find(id);
           context.Instruments.Remove(instrument);
           context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult DelIns(int id) {

            var ins = context.Instruments.Single(i => i.InstrumentId == id);

            //var delContribution = context.Contributions.Where(c => c.UncertaintyBudget.InstrumentId == id).ToList();
            //context.Contributions.RemoveRange(delContribution);

            //var delUnc = context.UncertaintyBudgets.Where(u => u.InstrumentId == id).ToList();
            //context.UncertaintyBudgets.RemoveRange(delUnc);

            //var delIns = context.Instruments.Where(i => i.InstrumentId == id).ToList();
            //context.Instruments.RemoveRange(delIns);

            //context.SaveChanges();

            //context.SaveChanges();
            //var InsId = context.UncertaintyBudgets.Single(ub => ub.UbId == .UbId).InstrumentId;
            //return RedirectToAction("PageView", new RouteValueDictionary(new { Controller = "Demo", Action = "PageView", Id = InsId }));
            //return RedirectToAction("Index");

            //var delInstrument = context.Instruments.Single(i => i.InstrumentId == id);
            //context.Instruments.Remove(delInstrument);
            //context.SaveChanges();

            return RedirectToAction("DeleteInstrument", new RouteValueDictionary(new { Controller = "Demo", Action = "DeleteInstrument", Id = id }));
        }

        //To Add A New Measurement Uncertainty Budget Table To An Instrument 
        public ActionResult AddNewUncertainty(int id)
        {
            var insQuery = context.Instruments.SingleOrDefault(c => c.InstrumentId == id);


            var addUncertainty = context.UncertaintyBudgets.Add(new UncertaintyBudget() { InstrumentId = id, AuthorId = 1, UserId = 1 });

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
            var ubTable = context.UncertaintyBudgets.Single(ub => ub.UbId == id);
            context.UncertaintyBudgets.Remove(ubTable);
            context.SaveChanges();


            return RedirectToAction("Index");
        }

        //Add Row To a Contribution
        public ActionResult AddContribution(int id)
        {
            var AddRow = context.Contributions.Add(new Contribution() { UbId = id });
            context.SaveChanges();

            var InsId = context.UncertaintyBudgets.Single(ub => ub.UbId == id).InstrumentId;
            return RedirectToAction("PageView", new RouteValueDictionary(new { Controller = "Demo", Action = "PageView", Id = InsId }));
        }
        // RedirectToAction("PageView", new RouteValueDictionary (new { Controller = "Demo", Action="PageView" , Id = InsId}));
        //Edit Contributions
        //**********************************************************************


        // GET: Contributions/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.UbId = new SelectList(context.UncertaintyBudgets, "UbId", "UbId", contribution.UbId);
            return View(contribution);
        }

        // POST: Contributions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContributionId,Symbol,Name,EstimatedValue,PdfId,StandardUncertainty,SensitivityCoefficient,Uncertainty,UbId")] Contribution contribution)
        {
            if (ModelState.IsValid)
            {
                context.Entry(contribution).State = EntityState.Modified;
                context.SaveChanges();

                var InsId = context.UncertaintyBudgets.Single(ub => ub.UbId == contribution.UbId).InstrumentId;
                return RedirectToAction("PageView", new RouteValueDictionary(new { Controller = "Demo", Action = "PageView", Id = InsId }));

                //return RedirectToAction("Index");
            }
            ViewBag.UbId = new SelectList(context.UncertaintyBudgets, "UbId", "UbId", contribution.UbId);
            return View(contribution);
        }

        // GET: Contributions/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Contributions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contribution contribution = context.Contributions.Find(id);
            context.Contributions.Remove(contribution);
            context.SaveChanges();


            var InsId = context.UncertaintyBudgets.Single(ub => ub.UbId == contribution.UbId).InstrumentId;
            return RedirectToAction("PageView", new RouteValueDictionary(new { Controller = "Demo", Action = "PageView", Id = InsId }));
            //return RedirectToAction("Index");
        }

       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}