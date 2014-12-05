using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Socrates.Models;

namespace Socrates.Controllers
{
    public class CourseController : SocratesController
    {
        // GET: Course
        public ActionResult Index()
        {
            var dept = context.Departments.Include("Courses").OrderBy(d => d.Name);
            //var dept = context.Departments.OrderBy(d => d.Name);
            return View(dept);
        }

        public ActionResult Detail(int id=1)
        {
            var crs = context.Courses.SingleOrDefault(d => d.Id == id);
            ViewBag.NoLayout = true;
            return View(crs);
        }
    }
}