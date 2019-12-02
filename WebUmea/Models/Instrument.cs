using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        [Display(Name = "Description")]
        public string  Description { get; set; }
    }
}