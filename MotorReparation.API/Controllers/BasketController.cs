using Microsoft.AspNetCore.Mvc;
using MotorReparation.Application.Contracts.Persistence;
using MotorReparation.Application.Contracts.Services;
using MotorReparation.Domain;

namespace MotorReparation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IBasketRepository _basketRepository;
        public BasketController(IBasketService basketService, IBasketRepository basketRepository)
        {
            _basketService = basketService;
            _basketRepository = basketRepository;

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
        public async Task<IActionResult> GetAllTicketsByBasketIdAsync(int id)
        {
/*            var result = await _basketService.GetAllTicketsByBasketIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);*/
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket(Basket basket)
        {
            var result = await _basketRepository.AddAsync(basket);
            if (result < 1)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
