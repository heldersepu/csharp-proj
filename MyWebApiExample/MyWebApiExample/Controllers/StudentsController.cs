using Microsoft.AspNetCore.Mvc;
using MyModels;
using System.Threading.Tasks;

namespace MyWebApiExample.Controllers
{
    [Produces("application/json")]
    [Route("api/Students")]
    public class StudentsController : Controller
    {
        /// <summary>
        /// Get Student
        /// </summary>
        /// <param name="id">student identifier</param>
        /// <returns>returns students</returns>
        [ProducesResponseType(typeof(Student), 200)]
        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Student student = new Student();
            return Ok(student);
        }
    }
}
