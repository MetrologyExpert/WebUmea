using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUmea.Models
{
    public class Instrument
    {   
        [Key]
        public int InstrumentId { get; set; }
        [Display(Name ="Instrument Name")]
        public string InstrumentName { get; set; }
        [Display(Name = "Instrument Model")]
        public string InstrumentModel { get; set; }
        [AllowHtml]
        [Display(Name = "Description")]
        public string  Description { get; set; }
    }
}