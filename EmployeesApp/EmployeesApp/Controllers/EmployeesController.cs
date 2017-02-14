using NLog;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Collections.Generic;
using EmployeesApp.Framework.DbSchema;
using EmployeesApp.DAL;
using System.Threading.Tasks;

namespace EmployeesApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeesController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get all employees on record
        /// </summary>
        /// <returns>Returns a list of all Employees</returns>
        public List<Employee> Get()
        {
            var response = new List<Employee>();
            try
            {
                response = Data.Employees;
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return response;
        }

        /// <summary>
        /// Get an employee
        /// </summary>
        /// <param name="id">The unique identifier</param>
        /// <returns>Returns the employee data for the given id </returns>
        public Employee Get(string id)
        {
            var response = new Employee();
            try
            {
                response = Data.Employee(id);
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return response;
        }

        /// <summary>
        /// Add a new employee
        /// </summary>
        /// <param name="employee">The employee data to add</param>
        /// <returns>Returns Status code 200 OK on success</returns>
        public async Task<IHttpActionResult> Post([FromBody]Employee employee)
        {
            try
            {
                return Ok(await Data.AddEmployee(employee));
            }
            catch (Exception e)
            {
                logger.Error(e);
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// Update an existing employee
        /// </summary>
        /// <param name="id">The unique identifier</param>
        /// <param name="employee">The employee data to update</param>
        /// <returns>Returns Status code 200 OK on success</returns>
        public async Task<IHttpActionResult> Put(string id, [FromBody]Employee employee)
        {
            try
            {
                var emp = await Data.UpdateEmployee(id, employee);
                if (emp == null)
                    return NotFound();
                return Ok(emp);
            }
            catch (Exception e)
            {
                logger.Error(e);
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// Delete an existing employee
        /// </summary>
        /// <param name="id">The unique identifier</param>
        /// <returns>Returns Status code 200 OK on success</returns>
        public async Task<IHttpActionResult> Delete(string id)
        {
            try
            {
               if (await Data.DeleteEmployee(id) == null)
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
