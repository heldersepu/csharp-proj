using NLog;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Collections.Generic;
using EmployeesApp.Framework.DbSchema;
using EmployeesApp.DAL;

namespace EmployeesApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BenefitsDiscountsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get the yearly benefits discounts
        /// </summary>
        /// <param name="bypassCache">Option to bypass the cache (default = false)</param>
        /// <returns>Returns the benefits discounts </returns>
        public List<BenefitsDiscount> Get(bool bypassCache = false)
        {
            var response = new List<BenefitsDiscount>();
            try
            {
                response = Data.Discounts(bypassCache);
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return response;
        }

        /// <summary>
        /// Get a yearly benefits discount
        /// </summary>
        /// <param name="id">The unique identifier</param>
        /// <returns>Returns the benefits discount data for the given id </returns>
        public BenefitsDiscount Get(int id)
        {
            var response = new BenefitsDiscount();
            try
            {
                response = Get(false).Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return response;
        }

        /// <summary>
        /// Add a new benefits discount
        /// </summary>
        /// <param name="benefitsDiscount">The benefits discount data to add</param>
        /// <returns>Returns Status code 200 OK on success</returns>
        public IHttpActionResult Post([FromBody]BenefitsDiscount benefitsDiscount)
        {
            try
            {
                Data.AddDiscount(benefitsDiscount);
                return Ok(Get(true));
            }
            catch (Exception e)
            {
                logger.Error(e);
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// Update an existing benefits discount
        /// </summary>
        /// <param name="id">The unique identifier</param>
        /// <param name="benefitsDiscount">The benefits discount data to update</param>
        /// <returns>Returns Status code 200 OK on success</returns>
        public IHttpActionResult Put(int id, [FromBody]BenefitsDiscount benefitsDiscount)
        {
            try
            {
                if (Data.UpdateDiscount(id, benefitsDiscount) == null)
                    return NotFound();
                return Ok(Get(true));
            }
            catch (Exception e)
            {
                logger.Error(e);
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// Delete an existing benefit discount
        /// </summary>
        /// <param name="id">The unique identifier</param>
        /// <returns>Returns Status code 200 OK on success</returns>
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (Data.DeleteDiscount(id) == null)
                    return NotFound();
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
