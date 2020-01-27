using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUmea.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }


    }
}