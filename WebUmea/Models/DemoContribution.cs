using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUmea.Models
{
    public class DemoContribution
    {
        public int CoId { get; set; }

        public string CoName { get; set; }
        public double CoEstdValue { get; set; }
        public double CoStdUncertainty { get; set; }

        public int UbIds { get; set; }

        public int InsId { get; set; }
    }
}