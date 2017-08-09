using System;
using System.Web.Http;

namespace WebApi_MyGet.Controllers
{
    public abstract class BaseController : ApiController
    {

        /// <summary>
        /// Get a record by the given key.
        /// </summary>
        public virtual long Get(long id)
        {
            return id;
        }

        /// <summary>
        /// Post a record.
        /// </summary>
        public virtual long Post([FromBody]string value)
        {
            return DateTime.Now.Ticks;
        }

        /// <summary>
        /// Put a record by the given key.
        /// </summary>
        public virtual long Put(long id, [FromBody]string value)
        {
            return id;
        }

        /// <summary>
        /// Delete a record by the given key.
        /// </summary>
        public virtual long Delete(long id)
        {
            return id;
        }
    }
}
