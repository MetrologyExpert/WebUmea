using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUmea.Models;


namespace WebUmea.Controllers
{
   
    public class InstMenuController : Controller
    {
        private ApplicationDbContext _context;

        public InstMenuController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
           _context.Dispose();
        }

        // GET: InstMenu
  
        public ActionResult Index()
        {
            var instrumentList = _context.Instruments.ToList();
            return View(instrumentList);
        }

        public ActionResult New()
        {
            return View();
        }

    
        [HttpPost]
        public ActionResult Create(Instrument instrument)
        {
           _context.Instruments.Add(instrument);
            _context.SaveChanges();

            return RedirectToAction("Index","InstMenu");
        }


        public ActionResult Details(int id)
        {
            var idNumber = _context.Instruments.SingleOrDefault(c => c.InstrumentId == id);

            Instrument instrument = idNumber;

            return View("New", instrument);
        }


    }
}