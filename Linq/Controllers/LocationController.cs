using BAL;
using Microsoft.AspNetCore.Mvc;

namespace Linq.Controllers
{
    [Route("api/product/location/report")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private ILocationService ProductionService;
        public LocationController(ILocationService productionService)
        {
            ProductionService = productionService;
        }


        [HttpGet]
        public async Task<ActionResult> GetTotalQuantity()
        {
            var data=await ProductionService.GetTotalQuantity();
            return Ok(data);
        }
    }
}
