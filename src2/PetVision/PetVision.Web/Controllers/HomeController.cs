using PetVision.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace PetVision.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult UploadImage()/*HttpPostedFileBase file*/
        {
            ViewBag.AlertStatus = "alert-danger";
            ViewBag.FileStatus = "Failed";
            var stream = this.Request.Files[0].InputStream;
            if (stream.Length == 0)
                return View("Index");

            var swriter = new FileStreamResult(stream, MediaTypeNames.Image.Jpeg);

            ViewBag.AlertStatus = "alert-success";
            ViewBag.FileStatus = "Success";

            return swriter;
            //return View("Index", new ImageToUpload { File = swriter, FileName = "Test" });
        }
    }
}