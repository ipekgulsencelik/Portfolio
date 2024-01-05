using Portfolio.Models;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
	public class RegisterController : Controller
    {
		PortfolioDBEntities db = new PortfolioDBEntities();

		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Index(Admin admin)
		{
			db.Admins.Add(admin);
			db.SaveChanges();
			return RedirectToAction("Index", "Login");
		}
	}
}