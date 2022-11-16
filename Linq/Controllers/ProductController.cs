using BAL;
using DAL;
using Linq.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Linq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
            private IProductService ProductService;
            public ProductController(IProductService productService)
            {
                ProductService = productService;
            }

            [HttpGet]
            public ActionResult<Product> GetAllProduct([FromQuery] ProductFilter filter)
            {
                var data = ProductService.GetAllProduct(filter);
                return Ok(data);
            }
    }
}

