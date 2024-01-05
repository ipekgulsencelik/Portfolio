using Portfolio.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Portfolio.Controllers
{
	public class LoginController : Controller
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
			var values = db.Admins.FirstOrDefault(x => x.NameSurname == admin.NameSurname && x.Password == admin.Password);
			if (values != null)
			{
				FormsAuthentication.SetAuthCookie(values.Username, false);
				Session["username"] = values.Username.ToString();
				return RedirectToAction("Index", "Service");
			}
			return View();
		}
	}
}