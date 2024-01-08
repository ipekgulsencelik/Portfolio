using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class ClientController : Controller
    {
        PortfolioDBEntities db = new PortfolioDBEntities();

        // GET: Client
        public ActionResult Index()
        {
            return View();
        }
    }
}