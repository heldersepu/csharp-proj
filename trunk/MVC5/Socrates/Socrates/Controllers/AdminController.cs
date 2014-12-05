using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Socrates.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            List<Object> data = new List<Object>();
            data.Add(122);
            data.Add("345");
            int i = 100;

            return View(data);
        }

        public ActionResult vIndex()
        {
            return View("View1");
        }

        public string strIndex()
        {
            return "Hello";
        }

        public string strH1Index()
        {
            return "<h1>Hello<h1>";
        }

        public int intIndex()
        {
            return 100;
        }
    }
}