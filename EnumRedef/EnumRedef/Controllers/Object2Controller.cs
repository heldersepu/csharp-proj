using EnumRedef.Models;
using System.Web.Http;

namespace EnumRedef.Controllers
{
    public class Object2Controller : ApiController
    {
        public Object2 Get()
        {
            return new Object2();
        }
    }
}