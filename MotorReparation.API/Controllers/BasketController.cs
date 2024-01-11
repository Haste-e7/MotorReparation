using Microsoft.AspNetCore.Mvc;
using MotorReparation.Application.Contracts.Persistence;
using MotorReparation.Application.Contracts.Services;
using MotorReparation.Domain;
using MotorReparation.Models.Commons;

namespace MotorReparation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IBasketRepository _basketRepository;
        private readonly ITicketRepository _ticketRepository;
        public BasketController(IBasketService basketService, IBasketRepository basketRepository, ITicketRepository ticketRepository)
        {
            _basketService = basketService;
            _basketRepository = basketRepository;
            _ticketRepository  = ticketRepository;
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


        [HttpGet]
        public async Task<IActionResult> GetAllTicketsByBasketIdAsync(int basketId)
        {
            var result = await _ticketRepository.GetAsync(t => t.BasketId == basketId, includeProperties: t=>t.Job);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

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
