using Portfolio.Models;
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
		public ActionResult UpdateAbout(About about)
		{
			var values = db.Abouts.Find(about.AboutID);
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