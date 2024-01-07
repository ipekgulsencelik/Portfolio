using Newtonsoft.Json.Linq;
using Portfolio.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
	public class AboutController : Controller
    {
		PortfolioDBEntities db = new PortfolioDBEntities();

		public ActionResult Index()
		{
			var values = db.Abouts.FirstOrDefault();
			return View(values);
		}

		[HttpGet]
		public ActionResult UpdateAbout(int id)
		{
			var values = db.Abouts.Find(id);
			return View(values);
		}

		[HttpPost]
		public ActionResult UpdateAbout(About about, System.Web.HttpPostedFileBase image)
		{
			var values = db.Abouts.Find(about.AboutID);

            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var path = "~/Images/" + uniqueFileName;
                image.SaveAs(Server.MapPath(path));
                about.AboutImage = uniqueFileName;
                values.AboutImage = about.AboutImage;
            }
            else
            {
                values.AboutImage = values.AboutImage;
            }

            values.NameSurname = about.NameSurname;
			values.Introduction = about.Introduction;
			values.Title = about.Title;
			values.Description = about.Description;
			values.AboutImage = about.AboutImage;			
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}