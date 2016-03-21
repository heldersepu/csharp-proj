using NLog;
using System;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Http.Cors;
using System.Collections.Generic;
using EmployeesApp.Models;

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
                using (var context = new DbModel())
                {
                    response = context.Employees.AsNoTracking()
                        .Include(x => x.Dependents).ToList();
                }
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
        public Employee Get(int id)
        {
            var response = new Employee();
            try
            {
                using (var context = new DbModel())
                {
                    response = context.Employees.AsNoTracking()
                        .Include(x => x.Dependents)
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
        /// Add a new employee
        /// </summary>
        /// <param name="employee">The employee data to add</param>
        /// <returns>Returns Status code 200 OK on success</returns>
        public IHttpActionResult Post([FromBody]Employee employee)
        {
            try
            {
                using (var context = new DbModel())
                {                    
                    context.Employees.Add(
                        new Employee
                        {
                            Name = employee.Name,
                            Email = employee.Email,
                            Age = employee.Age,
                            PaycheckAmount = employee.PaycheckAmount,
                            PaychecksPerYear = employee.PaychecksPerYear,
                            HireDate = employee.HireDate
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
        /// Update an existing employee
        /// </summary>
        /// <param name="id">The unique identifier</param>
        /// <param name="employee">The employee data to update</param>
        /// <returns>Returns Status code 200 OK on success</returns>
        public IHttpActionResult Put(int id, [FromBody]Employee employee)
        {
            try
            {
                using (var context = new DbModel())
                {
                    var emp = context.Employees.Where(x => x.Id == id).FirstOrDefault();
                    if (emp == null)
                        return NotFound();
                    emp.Name = employee.Name;
                    emp.Email = employee.Email;
                    emp.Age = employee.Age;
                    emp.PaycheckAmount = employee.PaycheckAmount;
                    emp.PaychecksPerYear = employee.PaychecksPerYear;
                    emp.HireDate = employee.HireDate;
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
        /// Delete an existing employee
        /// </summary>
        /// <param name="id">The unique identifier</param>
        /// <returns>Returns Status code 200 OK on success</returns>
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (var context = new DbModel())
                {
                    var emp = context.Employees.Where(x => x.Id == id).FirstOrDefault();
                    if (emp == null)
                        return NotFound();
                    context.Employees.Remove(emp);
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
