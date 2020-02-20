using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUmea.Models
{
    public class Contribution
    {
        [Key]
        public int ContributionId { get; set; }

        public string Symbol { get; set; }
        public string Name { get; set; }
        public double EstimatedValue { get; set; }

        //[ForeignKey("PdfId")]
        public int pdfId { get; set; }
        public double StandardUncertainty { get; set; }
        public double SensitivityCoefficient { get; set; }
        public string Uncertainty { get; set; }

        //Navigation Properties   

        //[ForeignKey("UbId")]
        public int UbId { get; set; }
        public UncertaintyBudget UncertaintyBudget { get; set; }
    }
}