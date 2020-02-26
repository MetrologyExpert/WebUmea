using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUmea.ViewModel
{
    public class InstrumentUncBudgetViewModel
    {
        public int ConId { get; set; }
        public int UbId { get; set; }
        public string QuantityName { get; set; }
        public string Pdf_Name { get; set; }
        public double StdUnc { get; set; }
        public string PdfName { get; set; }
        public string InsName { get; set; }
    }
}