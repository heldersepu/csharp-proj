using Microsoft.AspNetCore.Mvc;
using MyWebApiExample.Models;
using System.Threading.Tasks;

namespace MyWebApiExample.Controllers
{
    [Produces("application/json")]
    [Route("api/Teachers")]
    public class TeachersController : Controller
    {
        /// <summary>
        /// Get Teacher
        /// </summary>
        /// <param name="id">teacher identifier</param>
        /// <returns>returns teachers</returns>
        [ProducesResponseType(typeof(Teacher), 200)]
        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Teacher teacher = new Teacher();
            return Ok(teacher);
        }
    }
}
