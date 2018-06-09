using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi_NetCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Authors")]
    public class AuthorsController : Controller
    {
        [HttpPost(Name = "CreateAuthor")]
        public IActionResult CreateAuthor([FromBody] AuthorForCreationDto author)
        {
            return null;
        }

        [HttpPut(Name = "CreateAuthorWithDateOfDeath")]
        public IActionResult CreateAuthorWithDateOfDeath( [FromBody] AuthorForCreationWithDateOfDeathDto author)
        {
            return null;
        }
    }

    public class AuthorForCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Genre { get; set; }

        //public ICollection<BookForCreationDto> Books { get; set; }

    }

    public class AuthorForCreationWithDateOfDeathDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public DateTimeOffset? DateOfDeath { get; set; }
        public string Genre { get; set; }
    }
}