using Portfolio.Models;
using System.Linq;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
	public class ContactController : Controller
    {
		PortfolioDBEntities db = new PortfolioDBEntities();

		[HttpGet]
		public ActionResult Index()
		{
			ViewBag.description = db.Addresses.Select(x => x.Description).FirstOrDefault();
			ViewBag.phone = db.Addresses.Select(x => x.Phone).FirstOrDefault();
			ViewBag.addressDetails = db.Addresses.Select(x => x.AddressDetail).FirstOrDefault();
			ViewBag.mail = db.Addresses.Select(x => x.Mail).FirstOrDefault();
			return View();
		}

		[HttpPost]
		public ActionResult Index(Contact contact)
		{
			db.Contacts.Add(contact);
			db.SaveChanges();
			return RedirectToAction("Index", "Default");
		}

		public PartialViewResult _ScriptPartial()
		{
			return PartialView();
		}

		public ActionResult GetContact()
		{
			var values = db.Addresses.FirstOrDefault();
			return View(values);
		}

		[HttpGet]
		public ActionResult UpdateAddress(int id)
		{
			var value = db.Addresses.Find(id);
			return View(value);
		}

		[HttpPost]
		public ActionResult UpdateAddress(Address address)
		{
			var value = db.Addresses.Find(address.AddressID);
			value.Description = address.Description;
			value.Phone = address.Phone;
			value.AddressDetail = address.AddressDetail;
			value.Mail = address.Mail;
			db.SaveChanges();
			return RedirectToAction("GetContact");
		}

		public ActionResult MessageList()
		{
			var values = db.Contacts.ToList();
			return View(values);
		}

		public ActionResult DeleteMessage(int id)
		{
			var value = db.Contacts.Find(id);
			db.Contacts.Remove(value);
			db.SaveChanges();
			return RedirectToAction("MessageList");
		}

		public ActionResult MessageDetail(int id)
		{
			var value = db.Contacts.Find(id);
			return View(value);
		}
	}
}