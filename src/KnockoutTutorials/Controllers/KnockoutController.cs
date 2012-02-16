using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace KnockoutTutorials.Controllers
{
    public class KnockoutController : Controller
    {
        //
        // GET: /Knockout/
        private List<string> _pages = new List<string>() { "T01_Introduction", "T02_ListsAndCollections", "T03_SinglePageApplications", "T04_CreatingCustomBindings" };

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

        public ActionResult T03_SinglePageApplications()
        {
            return View();
        }

        public ActionResult T04_CreatingCustomBindings()
        {
            return View();
        }

        public ActionResult MailBoxFolder(string folder)
        {
            folder = folder.ToLower();
            var validFolders = new List<string> { "inbox", "archive", "sent", "spam" };
            if (!validFolders.Contains(folder))
                return null;

            string file = "~/MailBox/Folders/" + folder + ".json";

            return new ContentResult()
            {
                Content = System.IO.File.ReadAllText(Server.MapPath(Url.Content(file))),
                ContentType = "application/json"
            };
        }

        public ActionResult MailBoxItem(int mailId)
        {            
            if (mailId == 0) return null;

            string file = "~/MailBox/Items/" + mailId + ".json";
            string finalLocation = Server.MapPath(Url.Content(file));
            //if (!System.IO.File.Exists(finalLocation)) //Download items we don't have yet
            //    (new WebClient()).DownloadFile("http://learn.knockoutjs.com/mail?mailid=" + mailId, finalLocation);

            return new ContentResult()
            {
                Content = System.IO.File.ReadAllText(finalLocation),
                ContentType = "application/json"
            };
        }
    }
}
