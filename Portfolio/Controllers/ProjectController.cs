using Newtonsoft.Json.Linq;
using Portfolio.Models;
using System;
using System.Collections.Generic;
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
            List<SelectListItem> categories = (from x in db.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.category = categories;

            return View();
		}

		[HttpPost]
		public ActionResult AddProject(Project project, System.Web.HttpPostedFileBase image)
        {
            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var path = "~/Images/" + uniqueFileName;
                image.SaveAs(Server.MapPath(path));
                project.ProjectImage = uniqueFileName;
            }

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
            List<SelectListItem> categories = (from x in db.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.category = categories;

            var value = db.Projects.Find(id);
			return View(value);
		}

		[HttpPost]
		public ActionResult UpdateProject(Project project, System.Web.HttpPostedFileBase image)
        {
            var value = db.Projects.Find(project.ProjectID);

            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var path = "~/Images/" + uniqueFileName;
                image.SaveAs(Server.MapPath(path));
                project.ProjectImage = uniqueFileName;
                value.ProjectImage = project.ProjectImage;
            }
            else
            {
                value.ProjectImage = value.ProjectImage;
            }

			value.Title = project.Title;
            value.SubTitle = project.SubTitle;
			value.Description = project.Description;
            value.ProjectImage = project.ProjectImage;
            value.ProjectCategory = project.ProjectCategory;
            value.ProjectURL = project.ProjectURL;
            value.CompleteDay = project.CompleteDay;
			value.Price = project.Price;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

        public ActionResult ProjectDetails(int id)
        {
            var value = db.Projects.Find(id);
            return View(value);
        }
    }
}