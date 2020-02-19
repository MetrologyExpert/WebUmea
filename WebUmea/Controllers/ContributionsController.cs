using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebUmea.Models;

namespace WebUmea.Controllers
{
    public class ContributionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contributions
        public ActionResult Index()
        {
            var contributions = db.Contributions.Include(c => c.UncertaintyBudget);
            return View(contributions.ToList());
        }

        // GET: Contributions/Details/5
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

        // GET: Contributions/Create
        public ActionResult Create()
        {
            ViewBag.UbId = new SelectList(db.UncertaintyBudget, "UbId", "UbId");
            return View();
        }

        // POST: Contributions/Create
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

        // GET: Contributions/Edit/5
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

        // POST: Contributions/Edit/5
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

        // GET: Contributions/Delete/5
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

        // POST: Contributions/Delete/5
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
