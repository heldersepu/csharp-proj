using System.Web.Mvc;

namespace Socrates.Controllers
{
    public class RespController : Controller
    {
        // GET: Resp
        public ActionResult Index()
        {
            ViewBag.name = Request.Form["txtName"];
            return View();
        }
    }
}