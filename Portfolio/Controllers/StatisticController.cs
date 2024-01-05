using Portfolio.Models;
using System.Linq;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
	public class StatisticController : Controller
    {
		PortfolioDBEntities db = new PortfolioDBEntities();

		public ActionResult Index()
		{
			ViewBag.totalProjectCount = db.Projects.Count();
			ViewBag.totalTestimonialCount = db.Testimonials.Count();
			ViewBag.sumWorkDay = db.Projects.Sum(x => x.CompleteDay);
			ViewBag.avgWorkDay = db.Projects.Average(x => x.CompleteDay);

			ViewBag.avgPrice = db.Projects.Average(x => x.Price);
			//decimal averagePrice = (decimal)avgPrice;
			//string avgProjectPrice = averagePrice.ToString("0.00");
			//ViewBag.avgPrice = avgProjectPrice;
			
			var maxPrice = db.Projects.Max(x => x.Price);
			//ViewBag.maxPrice = db.Projects.Where(x => x.Price == maxPrice);
			ViewBag.maxProjectPrice = db.Projects.Where(x => x.Price == maxPrice).Select(y => y.Title).FirstOrDefault();

			var category = db.Categories.Where(x => x.CategoryName == "Asp.Net Core Web Development").Select(y => y.CategoryID).FirstOrDefault();
			ViewBag.categoryCountByName = db.Projects.Where(x => x.ProjectCategory == category).Count();

			return View();
		}
	}
}