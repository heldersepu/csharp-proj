using System.Linq;
using System.Web.Mvc;

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
            return View(crs);
        }
    }
}