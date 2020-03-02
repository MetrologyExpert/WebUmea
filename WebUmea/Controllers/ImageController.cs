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
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }


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

            db.Images.Add(imageModel);
                db.SaveChanges();
            
          

            ModelState.Clear();
                return View();
        }

        [HttpGet]
        public ActionResult View(int id) {

            Image imageModel = new Image();

            imageModel = db.Images.Where(x => x.ImageID == id).Single();

           return View(imageModel);
        }

        [HttpGet]
        public ActionResult MediaLibrary()
        {

            var library = db.Images.ToList();

            return View("MediaLibrary",library);

       
        }
    }
}