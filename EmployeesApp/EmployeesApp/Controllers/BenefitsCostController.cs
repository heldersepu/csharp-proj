using NLog;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Runtime.Caching;
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
        /// <param name="bypassCache">Option to bypass the cache (default = false)</param>
        /// <returns>Returns the yearly cost of benefits for employees and dependents</returns>
        public BenefitsCost Get(bool bypassCache = false)
        {
            var response = new BenefitsCost();
            try
            {
                var memCache = MemoryCache.Default.Get(Constants.Cache.BENEFITS_COST);
                if ((bypassCache) || (memCache == null))
                {
                    using (var context = new DbModel())
                    {
                        response = context.CostOfBenefits.AsNoTracking().FirstOrDefault();
                    }
                    var policy = new CacheItemPolicy { SlidingExpiration = TimeSpan.FromHours(1) };
                    MemoryCache.Default.Add(Constants.Cache.BENEFITS_COST, response, policy);
                }
                else
                {
                    response = (BenefitsCost)memCache;
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
