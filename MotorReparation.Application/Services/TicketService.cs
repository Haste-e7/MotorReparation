using Microsoft.AspNetCore.Identity;
using MotorReparation.Application.Contracts.Persistence;
using MotorReparation.Application.Contracts.Services;
using MotorReparation.Domain;

namespace MotorReparation.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public TicketService(ITicketRepository TicketRepository, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _ticketRepository = TicketRepository;
            _userManager = userManager;
        }
        public async Task<int> CreateTicketAsync(Ticket Ticket)
        {
            return await _ticketRepository.AddAsync(Ticket);
        }

        public Task<Ticket> DeleteTicketAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Ticket>> GetAllTicketsAsync()
        {
            return await _ticketRepository.GetAllAsync();
        }

        public async Task<IReadOnlyList<Ticket>> GetAllTicketsByBasketIdAsync(int basketId)
        {
            var Tickets = await _ticketRepository.GetAsync(bi => bi.BasketId == basketId);
            return Tickets;
        }

        public Task<Ticket> UpdateTicketAsync(Ticket Ticket)
        {
            throw new NotImplementedException();
        }

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            var result = await _ticketRepository.GetAsync(t=>t.Id == id,null,true, t => t.LaborUnits, t => t.PartUnits);
            var x = result.ToList()[0];
            return x;
        }
    }
}
  