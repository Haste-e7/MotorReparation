﻿using Microsoft.AspNetCore.Mvc;
using MotorReparation.Application.Contracts.Services;

namespace MotorReparation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController: ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService TicketService)
        {
            _ticketService = TicketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var result = await _ticketService.GetAllTicketsAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllTicketsByBasketIdAsync(int id)
        {
            var result = await _ticketService.GetAllTicketsByBasketIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
