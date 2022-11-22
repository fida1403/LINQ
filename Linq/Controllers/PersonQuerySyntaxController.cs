using BAL;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Linq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonQuerySyntaxController : ControllerBase
    {
        private IPersonService PersonService;
        public PersonQuerySyntaxController(IPersonService personService)
        {
            PersonService = personService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPersonQuerySyntax([FromQuery] PersonFilter filter)
        {
            var data = await PersonService.GetAllPersonQuerySyntax(filter);
            return Ok(data);
        }

        [HttpGet("sql")]
        public async Task<ActionResult> GetAllPersonSqlQuery([FromQuery] PersonFilter filter)
        {
            var data= await PersonService.GetAllPersonSqlQuery(filter);
            return Ok(data);
        }
    }
}
