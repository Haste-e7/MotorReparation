using Microsoft.AspNetCore.Mvc;
using MotorReparation.Application.Contracts;
using MotorReparation.Application.Services;

namespace MotorReparation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketItemController: ControllerBase
    {
        private readonly IBasketItemService _basketItemService;
        public BasketItemController(IBasketItemService basketItemService)
        {
            _basketItemService = basketItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBasketItems()
        {
            var result = await _basketItemService.GetAllBasketItemsAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllBasketItemsByBasketIdAsync(int id)
        {
            var result = await _basketItemService.GetAllBasketItemsByBasketIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
