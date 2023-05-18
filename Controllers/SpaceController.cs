using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginWeb_MVC.Controllers
{
    public class SpaceController : Controller
    {
        // GET: Space
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Space()
        {
            return View();
        }
    }
}