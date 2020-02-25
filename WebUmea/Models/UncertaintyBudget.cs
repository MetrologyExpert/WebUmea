using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUmea.Models
{
    public class UncertaintyBudget
    {   [Key]
        public int UbId { get; set; }

        public int InstrumentId { get; set; }

        public int AuthorId { get; set; }

        public int UserId { get; set; }
    }
}