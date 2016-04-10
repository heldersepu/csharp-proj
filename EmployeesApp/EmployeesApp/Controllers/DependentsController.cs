using NLog;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using EmployeesApp.Framework.DbSchema;
using EmployeesApp.DAL;

namespace EmployeesApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DependentsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get a dependent
        /// </summary>
        /// <param name="id">The unique identifier</param>
        /// <returns>Returns the dependent data for the given id </returns>
        public Dependent Get(int id)
        {
            var response = new Dependent();
            try
            {
                response = Data.Dependents.Where(x => x.Id == id).FirstOrDefault();
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
        /// <param name="dependent">The dependent data to add</param>
        /// <returns>Returns Status code 200 OK on success</returns>
        public IHttpActionResult Post(int empid, [FromBody]Dependent dependent)
        {
            try
            {
                var depend = Data.AddDependent(empid, dependent);
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
        /// <param name="id">The unique identifier</param>
        /// <returns>Returns Status code 200 OK on success</returns>
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (Data.DeleteDependent(id) == null)
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
