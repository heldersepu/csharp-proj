using System;
using System.Web.Mvc;

namespace Socrates.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string Hello(string message = "Hello")
        {
            return message + " From Home Controller";
        }

        public string Categ(string cat = "cat")
        {
            string str = RouteData.Values["cat"].ToString();
            return str;
        }

        public ActionResult strJSON(string message = "Hello")
        {
            var obj = new { FName = "John", LName = "Doe", Message = message };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration=5)]
        public string time()
        {
            return DateTime.Now.Ticks.ToString();
        }
    }
}