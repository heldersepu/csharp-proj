using NLog;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using EmployeesApp.Framework.DbSchema;
using EmployeesApp.DAL;
using System.Threading.Tasks;

namespace EmployeesApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DependentsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get a dependent
        /// </summary>
        /// <param name="empid">The employee id</param>
        /// <param name="id">The unique identifier</param>
        /// <returns>Returns the dependent data for the given id </returns>
        public Dependent Get(string empid, string id)
        {
            var response = new Dependent();
            try
            {
                response = Data.Dependent(empid, id);
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return response;
        }

        /// <summary>
        /// Add a new dependent
        /// </summary>
        /// <param name="empid">The employee id</param>
        /// <param name="dependent">The dependent data to add</param>
        /// <returns>Returns Status code 200 OK on success</returns>
        public async Task<IHttpActionResult> Post(string empid, [FromBody]Dependent dependent)
        {
            try
            {
                var depend = await Data.AddDependent(empid, dependent);
                if (depend == null)
                    return NotFound();
                return Ok(depend);
            }
            catch (Exception e)
            {
                logger.Error(e);
                return InternalServerError(e);
            }
        }


        /// <summary>
        /// Delete an existing dependent
        /// </summary>
        /// <param name="empid">The employee id</param>
        /// <param name="id">The unique identifier</param>
        /// <returns>Returns Status code 200 OK on success</returns>
        public async Task<IHttpActionResult> Delete(string empid, string id)
        {
            try
            {
                if (await Data.DeleteDependent(empid, id) == null)
                    return NotFound();
                return Ok();
            }
            catch (Exception e)
            {
                logger.Error(e);
                return InternalServerError(e);
            }
        }
    }
}
