using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObject.BasketModulesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController(IServiceManager _serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BasketDto>> GetBAsket(string Key)
        {
            var Basket =await _serviceManager.basketService.GetBasketAsync(Key);
            return Ok(Basket);
        }
        [HttpPost]
        public async Task<ActionResult<BasketDto>> CreateOrUpdateBasket(BasketDto basket)
        {
           var Basket= await _serviceManager.basketService.CreateOrUpdateBasketAsync(basket);
            return Ok(Basket);
        }
        [HttpDelete ("Key")]
        public async Task<ActionResult<bool>> DeleteBasket(string Key)
        {
            var result = await _serviceManager.basketService.DeleteBasketAsync(Key);
            return Ok(result);
        }



    }
}
