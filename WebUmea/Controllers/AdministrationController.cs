using Microsoft.AspNet.Identity;

using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUmea.Controllers
{
    public class AdministrationController : Controller
    {

        private readonly RoleManager<IdentityRole> roleManager;

         
        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }
    }
}