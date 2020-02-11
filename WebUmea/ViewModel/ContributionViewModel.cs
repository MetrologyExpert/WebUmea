using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUmea.Models;

namespace WebUmea.ViewModel
{
    public class ContributionViewModel
    {

        public List<Instrument> InstrumentView { get; set; }

        public List<Pdf> PdfView { get; set; }

        public List<Contribution> Contributions { get; set; }
    }
}