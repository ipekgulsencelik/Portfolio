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
			var values = db.Abouts.ToList();
			return View(values);
		}

		[HttpGet]
		public ActionResult AddAbout()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddAbout(About about)
		{
			var values = db.Abouts.Add(about);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteAbout(int id)
		{
			var values = db.Abouts.Find(id);
			db.Abouts.Remove(values);
			db.SaveChanges();
			return RedirectToAction("Index");
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