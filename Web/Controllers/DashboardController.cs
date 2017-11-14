using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fuel.Web.Controllers
{
    public class DashboardController : Controller
    {
        /*[Route("~/")]*/
        // GET: Dashboard
        public ActionResult Trainer()
        {
            return View();
        }
    }
}