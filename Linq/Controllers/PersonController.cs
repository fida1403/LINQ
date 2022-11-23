using BAL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Linq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonService PersonService;
        public PersonController(IPersonService personService)
        {
            PersonService = personService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPerson([FromQuery] PersonFilter filter)
        {
            var data = await PersonService.GetAllPerson(filter);
            return Ok(data);
        }
    }
}
