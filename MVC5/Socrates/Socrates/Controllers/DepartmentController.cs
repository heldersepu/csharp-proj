using System.Linq;
using System.Web.Mvc;
using Socrates.Models;

namespace Socrates.Controllers
{
    public class DepartmentController : SocratesController
    {
        // GET: Department
        public ActionResult Index()
        {            
            var departments = context.Departments.OrderBy(d => d.Name).ToList();
            return View(departments);
        }
        
        public ActionResult Edit(int id)
        {
            Department dept = context.Departments.SingleOrDefault(d => d.Id == id);
            return View(dept);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection coll)
        {
            var dept = new Department();
            if (TryUpdateModel(dept, coll))
            {
                context.Entry(dept).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Create()
        {
            return View(new Department());
        }
        
        [HttpPost]
        public ActionResult Create(FormCollection coll)
        {
            var dept = new Department();
            if (TryUpdateModel(dept, coll))
            {
                context.Entry(dept).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}