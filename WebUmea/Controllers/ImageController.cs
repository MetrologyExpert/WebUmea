using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUmea.Models;


namespace WebUmea.Controllers
{
    public class ImageController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Image
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Image imageModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff")+extension;
            imageModel.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            imageModel.ImageFile.SaveAs(fileName);
            context.Images.Add(imageModel);
            context.SaveChanges();

            ModelState.Clear();
                return View();
        }

        [HttpPost]
        public ActionResult View(int id) {

            Image imageModel = new Image();

            context.Images.Where(x => x.ImageID == id).FirstOrDefault();


            return View();
        }
    }
}