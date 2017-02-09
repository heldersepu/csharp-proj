using System;
using System.Linq;
using System.Web.Http;

namespace PlayMatrix.Controllers
{
    public class MatrixController : ApiController
    {
        static private Matrix matrix = new Matrix();

        // GET: api/Matrix/Create
        [HttpGet]
        public IHttpActionResult Create(int max)
        {
            DateTime sTime = DateTime.Now;
            if (max > matrix.Count)
                for (int i = matrix.Count; i < max; i++)
                    matrix.Add();
            return Ok(
                new Data {
                    data = matrix.Count,
                    milisec_elapsed = sTime.Diff() });
        }

        // GET: api/Matrix/Get
        [HttpGet]
        public IHttpActionResult Get(int take, int skip)
        {
            if (take > 100000)
                return BadRequest("You can NOT get more than 100000 records at a time");

            DateTime sTime = DateTime.Now;
            return Ok(
                new Data
                {
                    data = matrix.Take(take).Skip(skip),
                    milisec_elapsed = sTime.Diff()
                });
        }
    }
}
