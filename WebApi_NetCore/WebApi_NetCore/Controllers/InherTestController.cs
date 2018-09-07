using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi_NetCore.Controllers
{
    [Produces("application/json")]
    [Route("api/InherTest")]
    public class InherTestController : BaseController
    {
        public InherTestController(string repository) : base(repository)
        {
            //In here I will just inherit from the methods from the 
            //BaseController
        }
    }

    public abstract class BaseController : Controller
    {
        protected string _repo;

        public BaseController(string repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public virtual string Get(string repository)
        {
            return "test";
        }

        [HttpGet("{id:int}")]
        [Route("GetByID")]
        public async virtual Task<IActionResult> GetByIntID(int id)
        {
            try
            { 
                return Ok(1);
            }
            catch (Exception exp)
            {
                return BadRequest("Bad Request");
            }
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async virtual Task<IActionResult> Post(string dto)
        {
            return Ok("");
        }

        [HttpPut]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async virtual Task<IActionResult> Put(string dto)
        {
            return Ok("");
        }
    }
}