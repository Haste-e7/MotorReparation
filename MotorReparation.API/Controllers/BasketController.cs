using Microsoft.AspNetCore.Mvc;
using MotorReparation.Application.Contracts;

namespace MotorReparation.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _BasketService;
        public BasketController(IBasketService BasketService)
        {
            _BasketService = BasketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBaskets()
        {
            var result = await _BasketService.GetAllBasketsAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasketById(int id)
        {
            var result = await _BasketService.GetBasketByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
