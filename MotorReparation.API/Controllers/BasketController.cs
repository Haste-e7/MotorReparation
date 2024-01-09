using Microsoft.AspNetCore.Mvc;
using MotorReparation.Application.Contracts;

namespace MotorReparation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBaskets()
        {
            var result = await _basketService.GetAllBasketsAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasketById(int id)
        {
            var result = await _basketService.GetBasketByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
