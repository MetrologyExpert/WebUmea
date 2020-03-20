using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebUmea.Models;

namespace WebUmea.Controllers
{
    public class ApiDemoController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/InstrumentsApi
        [HttpGet]
        public Instrument GetInstruments()
        {
            return db.Instruments.FirstOrDefault(c => c.InstrumentId==1);
        }
    }
}
