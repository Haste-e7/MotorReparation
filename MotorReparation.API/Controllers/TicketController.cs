using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorReparation.Application.Contracts.Persistence;
using MotorReparation.Application.Contracts.Services;
using MotorReparation.Application.Services;
using MotorReparation.Domain;
using MotorReparation.Infrastructure.Repositories;
using MotorReparation.Models.Commons;

namespace MotorReparation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController: ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly ITicketRepository _ticketRepository;
        public TicketController(ITicketService TicketService, ITicketRepository TicketRepository)
        {
            _ticketService = TicketService;
            _ticketRepository = TicketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets(int basketId)
        {
            var result = new List<Ticket>();    
            if (User.IsInRole(SD.Role_Admin))
            {
                result = (List<Ticket>)await _ticketService.GetAllTicketsAsync();
            }
            else if (User.IsInRole(SD.Role_Customer) && basketId != null)
            {
                result = (List<Ticket>)await _ticketRepository.GetAsync(t => t.BasketId == basketId, includeProperties: t => t.Job);
            }
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            var result = await _ticketService.GetTicketByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {
            var result = await _ticketRepository.AddAsync(ticket);
            if (result < 1)
            {
                return NotFound();
            }
            return Ok(ticket.Id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTicket(Ticket ticket)
        {
            var result = await _ticketRepository.UpdateAsync(ticket);
            if (result < 1)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTicket(Ticket ticket)
        {
            var result = await _ticketRepository.DeleteAsync(ticket);
            if (result < 1)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
