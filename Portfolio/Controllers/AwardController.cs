using Portfolio.Models;
using System.Linq;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class AwardController : Controller
    {
        PortfolioDBEntities db = new PortfolioDBEntities();

        public ActionResult Index()
        {
            var values = db.Awards.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult AddAward()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAward(Award award)
        {
            db.Awards.Add(award);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAward(int id)
        {
            var values = db.Awards.Find(id);
            db.Awards.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAward(int id)
        {
            var value = db.Awards.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAward(Award award)
        {
            var value = db.Awards.Find(award.AwardID);
            value.Title = award.Title;
            value.Description = award.Description;
            value.ImageURL = award.ImageURL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}