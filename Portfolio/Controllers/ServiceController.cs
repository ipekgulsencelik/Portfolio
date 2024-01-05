using Portfolio.Models;
using System.Linq;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
	public class ServiceController : Controller
    {
		PortfolioDBEntities db = new PortfolioDBEntities();

		public ActionResult Index()
        {
			var values = db.Services.ToList();
			return View(values);
		}

		[HttpGet]
		public ActionResult AddService()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddService(Service service)
		{
			db.Services.Add(service);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteService(int id)
		{
			var values = db.Services.Find(id);
			db.Services.Remove(values);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult UpdateService(int id)
		{
			var value = db.Services.Find(id);
			return View(value);
		}

		[HttpPost]
		public ActionResult UpdateService(Service service)
		{
			var value = db.Services.Find(service.ServiceID);
			value.ServiceName = service.ServiceName;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}