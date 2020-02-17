using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUmea.Models
{
    public class DemoInstrument
    {
        public int InstrumentIds { get; set; }

        public string InstrumentNames { get; set; }

        public string InsModel { get; set; }

        public string InsManufacturer { get; set; }

        public string InsDescription { get; set; }

        public int UbIds { get; set; }

        public int CoId { get; set; }

        public double EstdValue { get; set; }

        public double StdUncertainty { get; set; }
    }
}