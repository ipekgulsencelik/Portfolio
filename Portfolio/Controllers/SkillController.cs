using Portfolio.Models;
using System.Linq;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
	public class SkillController : Controller
    {
		PortfolioDBEntities db = new PortfolioDBEntities();
		
		public ActionResult Index()
        {
			var values = db.Skills.ToList();
			return View(values);
		}

		[HttpGet]
		public ActionResult AddSkill()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddSkill(Skill skill)
		{
			db.Skills.Add(skill);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteSkill(int id)
		{
			var value = db.Skills.Find(id);
			db.Skills.Remove(value);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult UpdateSkill(int id)
		{
			var value = db.Skills.Find(id);
			return View(value);
		}

		[HttpPost]
		public ActionResult UpdateSkill(Skill skill)
		{
			var value = db.Skills.Find(skill.SkillID);
			value.SkillTitle = skill.SkillTitle;
			value.SkillValue = skill.SkillValue;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}