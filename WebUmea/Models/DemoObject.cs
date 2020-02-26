using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUmea.Models
{
    public class DemoObject
    {
        
        public int UbIds { get; set; }

        public Author Author { get; set; }

        public int ContributionIds { get; set; }
        public string ContributionName { get; set; }
        public double ContributionEstimatedValue { get; set; }
        public double ContributionSensitivityCoefficient { get; set; }
        public double StandardUncertainty { get; set; }

        public string PdfName { get; set; }

        public int InsId { get; set; }

    }
}