using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebUmea.Models;
using WebUmea.ViewModel;

namespace WebUmea.Controllers
{
    public class ContributionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contribution
        public ActionResult Index()
        {
            var contribution = db.Contributions.Include(i => i.UncertaintyBudget).ToList();
            var instrument = db.Instruments.ToList();
            var pdfs = db.Pdfs.ToList();

            ContributionViewModel contributionViewModel = new ContributionViewModel() {
                Contributions = contribution,
                InstrumentView = instrument,
                PdfView = pdfs };

            return View(contributionViewModel);
        }

        // GET: Contribution/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contribution contribution = db.Contributions.Find(id);
            if (contribution == null)
            {
                return HttpNotFound();
            }
            return View(contribution);
        }

        // GET: Contribution/Create
        public ActionResult Create()
        {
            ViewBag.UbId = new SelectList(db.UncertaintyBudget, "UbId", "UbId");
            return View();
        }

        // POST: Contribution/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContributionId,Symbol,Name,EstimatedValue,PdfId,StandardUncertainty,SensitivityCoefficient,Uncertainty,UbId")] Contribution contribution)
        {
            if (ModelState.IsValid)
            {
                db.Contributions.Add(contribution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UbId = new SelectList(db.UncertaintyBudget, "UbId", "UbId", contribution.UbId);
            return View(contribution);
        }

        // GET: Contribution/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contribution contribution = db.Contributions.Find(id);
            if (contribution == null)
            {
                return HttpNotFound();
            }
            ViewBag.UbId = new SelectList(db.UncertaintyBudget, "UbId", "UbId", contribution.UbId);
            return View(contribution);
        }

        // POST: Contribution/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContributionId,Symbol,Name,EstimatedValue,PdfId,StandardUncertainty,SensitivityCoefficient,Uncertainty,UbId")] Contribution contribution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contribution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UbId = new SelectList(db.UncertaintyBudget, "UbId", "UbId", contribution.UbId);
            return View(contribution);
        }

        // GET: Contribution/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contribution contribution = db.Contributions.Find(id);
            if (contribution == null)
            {
                return HttpNotFound();
            }
            return View(contribution);
        }

        // POST: Contribution/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contribution contribution = db.Contributions.Find(id);
            db.Contributions.Remove(contribution);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
