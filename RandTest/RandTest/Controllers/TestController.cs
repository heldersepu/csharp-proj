using NLog;
using System;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Http.Cors;
using RandTest.Models;

namespace RandTest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TestController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static Random rnd = new Random();

        /// <summary>
        /// Get all the questions for a test
        /// </summary>
        /// <param name="id">Id of the test to retrieve</param>
        /// <returns>returns all questions and choices for a given test</returns>
        public Test Get(int id = 1)
        {            
            var response = new Test();
            try
            {
                using (var context = new DbModel())
                {
                    response = context.Tests.AsNoTracking()
                        .Where(x => x.Id == id)
                        .Include("Questions")
                        .Include("Questions.Choices")
                        .FirstOrDefault();
                    if (response != null)
                    {
                        response.Questions = response.Questions.OrderBy(item => rnd.Next()).ToList();
                        foreach (var question in response.Questions)
                            question.Choices = question.Choices.OrderBy(item => rnd.Next()).ToList();
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            
            return response;

        }
    }
}
