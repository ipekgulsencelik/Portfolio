using Portfolio.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class CvController : Controller
    {
        PortfolioDBEntities db = new PortfolioDBEntities();

        [HttpGet]
        public ActionResult Index()
        {
            var value = db.CVs.FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public ActionResult Index(CV model, System.Web.HttpPostedFileBase cv)
        {
            var value = db.CVs.Find(1);

            string uniqueFileName = null;

            if (cv != null)
            {
                uniqueFileName = "CV";
                var path = "~/Templates/CV/" + uniqueFileName;
                cv.SaveAs(Server.MapPath(path));
                uniqueFileName = "~/Templates/CV/CV.pdf";
                model.URL = uniqueFileName;
                value.URL = model.URL;
            }
            else
            {
                value.URL = value.URL;
            }

            value.Name = "CV";
            value.URL = model.URL;
            value.CreateDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileResult GetCV()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/Templates/CV/" + "CV"));
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }
    }
}