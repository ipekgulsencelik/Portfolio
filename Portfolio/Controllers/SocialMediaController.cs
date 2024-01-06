using Portfolio.Models;
using System.Linq;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
	public class SocialMediaController : Controller
    {
		PortfolioDBEntities db = new PortfolioDBEntities();

		public ActionResult Index()
		{
			var values = db.SocialMedias.ToList();
			return View(values);
		}

		[HttpGet]
		public ActionResult AddSocialMedia()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddSocialMedia(SocialMedia account)
		{
			db.SocialMedias.Add(account);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteSocialMedia(int id)
		{
			var values = db.SocialMedias.Find(id);
			db.SocialMedias.Remove(values);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult UpdateSocialMedia(int id)
		{
			var value = db.SocialMedias.Find(id);
			return View(value);
		}

		[HttpPost]
		public ActionResult UpdateSocialMedia(SocialMedia account)
		{
			var value = db.SocialMedias.Find(account.SocialMediaID);
			value.AccountURL = account.AccountURL;
			value.Icon = account.Icon;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}