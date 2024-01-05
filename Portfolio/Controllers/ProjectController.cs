using Portfolio.Models;
using System.Linq;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
	public class ProjectController : Controller
    {
		PortfolioDBEntities db = new PortfolioDBEntities();

		public ActionResult Index()
		{
			var values = db.Projects.ToList();
			return View(values);
		}

		[HttpGet]
		public ActionResult AddProject()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddProject(Project project)
		{
			db.Projects.Add(project);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteProject(int id)
		{
			var value = db.Projects.Find(id);
			db.Projects.Remove(value);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult UpdateProject(int id)
		{
			var value = db.Projects.Find(id);
			return View(value);
		}

		[HttpPost]
		public ActionResult UpdateProject(Project project)
		{
			var value = db.Projects.Find(project.ProjectID);
			value.Title = project.Title;
			value.Description = project.Description;
			//value.CompleteDay = project.CompleteDay;
			//value.Price = project.Price;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}