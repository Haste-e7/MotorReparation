using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MotorReparation.Application.Contracts.Persistence;
using MotorReparation.Application.Contracts.Services;
using MotorReparation.Domain;

namespace MotorReparation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IBasketRepository _basketRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly UserManager<AppUser> _userManager; 
        public BasketController(IBasketService basketService, IBasketRepository basketRepository, ITicketRepository ticketRepository, UserManager<AppUser> userManager)
        {
            _basketService = basketService;
            _basketRepository = basketRepository;
            _userManager = userManager;
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
            var user = await _userManager.FindByIdAsync(basket.CustomerId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{basket.CustomerId}'.");
            }
            user.BasketId = basket.Id;
            await _userManager.UpdateAsync(user);
            return Ok(basket.Id);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(int id)
        {
            var b = await _basketRepository.GetByIdAsync(id);
            if (b != null) 
            {
                await _basketRepository.DeleteAsync(b);
            }
            return Ok();
        }
    }
}
