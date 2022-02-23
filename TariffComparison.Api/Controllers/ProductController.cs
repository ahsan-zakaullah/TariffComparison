using Microsoft.AspNetCore.Mvc;
using TariffComparison.Services.IServices;

namespace TariffComparison.Api.Controllers
{
    [Route("Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll(double consumption)
        {
            if (consumption < 0)
                return BadRequest("Consumption must non negative");
            return Ok(_productService.GetAll(consumption));

        }
    }
}
