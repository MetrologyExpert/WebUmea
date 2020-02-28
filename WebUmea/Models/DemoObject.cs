using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUmea.Models
{
    public class DemoObject
    {
        public int coId { get; set; }

        public string coSym { get; set; }

        public string coName { get; set; }

        public double coEstimatedValue { get; set; }

        public double coStdUnc { get; set; }

        public double coSC { get; set; }

        public string Distribution { get; set; }

        public string InsName { get; set; }

        public string AuName { get; set; }

        public int ubID { get; set; }

        public double StdUncCalc { get; set; }
        

    }
}