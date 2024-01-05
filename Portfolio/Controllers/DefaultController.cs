using Portfolio.Models;
using System.Linq;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
	public class DefaultController : Controller
    {
		PortfolioDBEntities db = new PortfolioDBEntities();
		
		public ActionResult Index()
        {
            return View();
        }

		public PartialViewResult _HeadPartial()
		{
			return PartialView();
		}

		public PartialViewResult _NavbarPartial()
		{
			return PartialView();
		}

		public PartialViewResult _QuickContactPartial()
		{
			var value = db.SocialMedias.ToList();
			return PartialView(value);
		}

		public PartialViewResult _FeaturePartial()
		{
			ViewBag.description = db.Abouts.Select(x => x.Description).FirstOrDefault();
			ViewBag.introduction = db.Abouts.Select(x => x.Introduction).FirstOrDefault();
			ViewBag.title = db.Abouts.Select(x => x.Title).FirstOrDefault();
			ViewBag.name = db.Abouts.Select(x => x.NameSurname).FirstOrDefault();
			ViewBag.image = db.Abouts.Select(x => x.AboutImage).FirstOrDefault();

			var value = db.SocialMedias.ToList();
			return PartialView(value);
		}

		public PartialViewResult _ServicePartial()
		{
			var value = db.Services.ToList();
			return PartialView(value);
		}

		public PartialViewResult _SkillPartial()
		{
			var value = db.Skills.ToList();
			return PartialView(value);
		}

		public PartialViewResult _AwardPartial()
		{
			var value = db.Awards.ToList();
			return PartialView(value);
		}

		public PartialViewResult _TestimonialPartial()
		{
			var value = db.Testimonials.ToList();
			return PartialView(value);
		}

		public PartialViewResult _ClientPartial()
		{
			ViewBag.ProjectCount = db.Projects.Count();
			ViewBag.TestimonialCount = db.Testimonials.Count();
			ViewBag.ClientCount = db.Clients.Count();

			var values = db.Clients.ToList();
			return PartialView(values);
		}

		public PartialViewResult _ContactPartial()
		{
			ViewBag.description = db.Addresses.Select(x => x.Description).FirstOrDefault();
			ViewBag.phone = db.Addresses.Select(x => x.Phone).FirstOrDefault();
			ViewBag.addressDetails = db.Addresses.Select(x => x.AddressDetail).FirstOrDefault();
			ViewBag.mail = db.Addresses.Select(x => x.Mail).FirstOrDefault();

			return PartialView();
		}

		[HttpPost]
		public ActionResult _ContactPartial(Contact contact)
		{
			db.Contacts.Add(contact);
			db.SaveChanges();
			return RedirectToAction("Index", "Default");
		}

		public PartialViewResult _FooterPartial()
		{
			return PartialView();
		}
	}
}