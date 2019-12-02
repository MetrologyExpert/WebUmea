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
            
            return View();
        }
    }
}