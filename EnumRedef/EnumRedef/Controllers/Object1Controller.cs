using EnumRedef.Models;
using System.Web.Http;

namespace EnumRedef.Controllers
{
    public class Object1Controller : ApiController
    {
        public Object1 Get()
        {
            return new Object1();
        }
    }
}
