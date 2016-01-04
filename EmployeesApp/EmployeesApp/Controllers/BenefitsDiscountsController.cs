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
    public class BenefitsDiscountsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get the yearly benefits discounts
        /// </summary>
        /// <returns>Returns the benefits discounts </returns>
        public List<BenefitsDiscount> Get()
        {
            var response = new List<BenefitsDiscount>();
            try
            {
                using (var context = new DbModel())
                {
                    response = context.BenefitDiscounts.AsNoTracking().ToList();
                }
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
                using (var context = new DbModel())
                {
                    response = context.BenefitDiscounts.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
                }
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
                using (var context = new DbModel())
                {
                    context.BenefitDiscounts.Add(
                        new BenefitsDiscount
                        {
                            Percentage = benefitsDiscount.Percentage,
                            Type = benefitsDiscount.Type,
                            Value = benefitsDiscount.Value,
                            Description = benefitsDiscount.Description
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
        /// Update an existing benefits discount
        /// </summary>
        /// <param name="id">The unique identifier</param>
        /// <param name="benefitsDiscount">The benefits discount data to update</param>
        /// <returns>Returns Status code 200 OK on success</returns>
        public IHttpActionResult Put(int id, [FromBody]BenefitsDiscount benefitsDiscount)
        {
            try
            {
                using (var context = new DbModel())
                {
                    var bd = context.BenefitDiscounts.Where(x => x.Id == id).FirstOrDefault();
                    if (bd == null)
                        return NotFound();
                    bd.Percentage = benefitsDiscount.Percentage;
                    bd.Type = benefitsDiscount.Type;
                    bd.Value = benefitsDiscount.Value;
                    bd.Description = benefitsDiscount.Description;
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
        /// Delete an existing benefit
        /// </summary>
        /// <param name="id">The unique identifier</param>
        /// <returns>Returns Status code 200 OK on success</returns>
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (var context = new DbModel())
                {
                    var bd = context.BenefitDiscounts.Where(x => x.Id == id).FirstOrDefault();
                    if (bd == null)
                        return NotFound();
                    context.BenefitDiscounts.Remove(bd);
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
