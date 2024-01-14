using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MotorReparation.Application.Contracts.Persistence;
using MotorReparation.Domain;
using MotorReparation.Models.Commons;
using System.Security.Claims;

namespace MotorReparation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AppUserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IBasketRepository _basketRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AppUserController(UserManager<AppUser> userManager, IBasketRepository basketRepository, ITicketRepository ticketRepository,IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _basketRepository = basketRepository;
            _ticketRepository = ticketRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserBaskets(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{id}'.");
            }
            var basket = await _basketRepository.GetByIdAsync(user.BasketId);
            var tickets = await _ticketRepository.GetAsync(t => t.BasketId == basket.Id, includeProperties: t => t.Job);

            basket.Tickets = (ICollection<Ticket>)tickets;
            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserTicket(string userId, Ticket ticket)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }
            var basket = await _basketRepository.GetByIdAsync(user.BasketId);
            if (basket == null)
            {
                var newBasket = new Basket() { CustomerId = userId };
                await _basketRepository.AddAsync(newBasket);
                ticket.BasketId = newBasket.Id;
                user.BasketId = newBasket.Id;
                await _userManager.UpdateAsync(user);
            }
            await _ticketRepository.AddAsync(ticket);
            //var basketId = _httpContextAccessor.HttpContext.User.FindFirstValue("BasketId");
            return Ok(ticket.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUserInRole(string role)
        {
         
            var result = await _userManager.GetUsersInRoleAsync(role);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
