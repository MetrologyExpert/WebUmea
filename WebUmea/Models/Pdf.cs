using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUmea.Models
{
    public class Pdf
    {   [Key]
        public int IdNumber { get; set; }
        public string Name { get; set; }

        public double Coefficient { get; set; }
    }
}