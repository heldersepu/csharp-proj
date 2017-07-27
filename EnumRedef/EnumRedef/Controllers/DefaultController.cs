using EnumRedef.Models;
using System.Web.Http;

namespace EnumRedef.Controllers
{
    public class DefaultController : ApiController
    {
        public MyObject Post(MyObject obj)
        {
            return obj;
        }
    }
}
