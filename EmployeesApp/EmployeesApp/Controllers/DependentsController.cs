using NLog;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Collections.Generic;
using EmployeesApp.Models;

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
                using (var context = new DbModel())
                {
                    response = context.Dependents.AsNoTracking()
                        .Where(x => x.Id == id).FirstOrDefault();
                }
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
                using (var context = new DbModel())
                {
                    var emp = context.Employees.Where(x => x.Id == empid).FirstOrDefault();
                    if (emp == null)
                        return NotFound();
                    if (emp.Dependents == null)
                        emp.Dependents = new List<Dependent>();
                    emp.Dependents.Add(
                        new Dependent
                        {
                            Name = dependent.Name,
                            Relationship = dependent.Relationship,
                            Age = dependent.Age,
                            Email = dependent.Email
                        }
                    );
                    context.SaveChanges();
                }
                return Ok();
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
                using (var context = new DbModel())
                {
                    var dep = context.Dependents.Where(x => x.Id == id).FirstOrDefault();
                    if (dep == null)
                        return NotFound();
                    context.Dependents.Remove(dep);
                    context.SaveChanges();
                }
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
