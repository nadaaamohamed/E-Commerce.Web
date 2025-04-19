using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IServiceManager serviceManager) :ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductDto>>> GetAllProduct([FromQuery]ProductQueryParams queryParams)
        {
            var products =await serviceManager.productService.GetProductsAsync(queryParams);
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        public async Task <ActionResult<ProductDto>> GetProductById(int id)
        {
            var Products=await serviceManager.productService.GetProductByIdAsync(id);
           return Ok(Products); 
        }
        [HttpGet ("types")]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllTypes()
        {
            var types = serviceManager.productService.GetAllTypesAsync();
            return Ok(types);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
        {
            var brands =await serviceManager.productService.GetAllBrandsAsync();
            return Ok(brands);

        }

    }
}
