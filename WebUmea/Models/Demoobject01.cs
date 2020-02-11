using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUmea.Models
{
    public class Demoobject01
    {
        public int ubId { get; set; }
        public string aAuthor { get; set; }
        public string iInstrument { get; set; }
        public string iManufacturer { get; set; }
        public string iModel { get; set; }
        public int cContributionId { get; set; }
        public string cSymbol { get; set; }
        public string Name { get; set; }
        public double cEstimatedValues { get; set; }
        public int cPdfId { get; set; }
        public double cCoeff { get; set; }
        public double cSU { get; set; }
        public double cSensCoeff  { get; set; }
    }
}