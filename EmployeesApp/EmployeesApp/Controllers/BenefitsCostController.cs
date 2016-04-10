using NLog;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using EmployeesApp.Framework.DbSchema;
using EmployeesApp.DAL;

namespace EmployeesApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BenefitsCostController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get the yearly cost of benefits
        /// </summary>
        /// <param name="bypassCache">Option to bypass the cache (default = false)</param>
        /// <returns>Returns the yearly cost of benefits for employees and dependents</returns>
        public BenefitsCost Get(bool bypassCache = false)
        {
            var response = new BenefitsCost();
            try
            {
                response = Data.Costs(bypassCache);
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
                Data.UpdateCosts(benefitsCost);
                return Ok(Get(true));
            }
            catch (Exception e)
            {
                logger.Error(e);
                return InternalServerError(e);
            }
        }
    }
}
