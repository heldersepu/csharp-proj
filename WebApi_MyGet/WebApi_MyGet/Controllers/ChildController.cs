using System.Collections.Generic;

namespace WebApi_MyGet.Controllers
{
    public class ChildController : BaseController<long>
    {
        /// <summary>
        /// Get some ...
        /// </summary>
        public IEnumerable<string> Get()
        {
            return new string[] { "aei", "bcd" };
        }
    }
}
