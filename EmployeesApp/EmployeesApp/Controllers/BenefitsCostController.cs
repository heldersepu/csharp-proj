using NLog;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using EmployeesApp.Models;

namespace EmployeesApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BenefitsCostController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get the yearly cost of benefits
        /// </summary>
        /// <returns>Returns the yearly cost of benefits for employees and dependents</returns>
        public BenefitsCost Get()
        {
            var response = new BenefitsCost();
            try
            {
                using (var context = new DbModel())
                {
                    response = context.CostOfBenefits.AsNoTracking().FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return response;
        }

        /// <summary>
        /// Updates the existing benefits costs
        /// </summary>
        /// <param name="benefitsCost">The new benefits </param>
        /// <returns>Return Status code 200 OK on success</returns>
        public IHttpActionResult Post([FromBody]BenefitsCost benefitsCost)
        {
            try
            {
                using (var context = new DbModel())
                {
                    var bCosts = context.CostOfBenefits.FirstOrDefault();
                    bCosts.Employee = benefitsCost.Employee;
                    bCosts.Dependent = benefitsCost.Dependent;
                    bCosts.Description = benefitsCost.Description;
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
