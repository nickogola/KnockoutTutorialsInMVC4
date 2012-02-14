using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnockoutTutorials.Controllers
{
    public class KnockoutController : Controller
    {
        //
        // GET: /Knockout/
        private List<string> _pages = new List<string>() { "T01_Introduction", "T02_ListsAndCollections" };

        public ActionResult Index()
        {
            return View(_pages);
        }

        public ActionResult T01_Introduction()
        {
            return View();
        }

        public ActionResult T02_ListsAndCollections()
        {
            return View();
        }
    }
}
