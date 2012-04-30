using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using KnockoutTutorials.Models;

namespace KnockoutTutorials.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() { return View(); }

        public ActionResult T01_Introduction() { return View(); }

        public ActionResult T02_ListsAndCollections() { return View(); }

        public ActionResult T03_SinglePageApplications() { return View(); }

        public ActionResult T04_CreatingCustomBindings() { return View(); }

        public ActionResult T05_LoadingAndSavingData() { return View(); }

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

        private static List<Task> _tasks;

        [HttpGet]
        public ActionResult Tasks()
        {
            if (_tasks == null)
            {
                var javascriptSerializer = new JavaScriptSerializer();
                _tasks = javascriptSerializer.Deserialize<List<Task>>(System.IO.File.ReadAllText(Server.MapPath(Url.Content("~/TaskData/Tasks.json"))));
            }

            //if (Request.HttpMethod == "GET")
            return Json(_tasks, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Tasks(List<Task> tasks)
        {
            _tasks = (from t in tasks
                      where !t._destroy
                      select t).ToList();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}
