using MotorReparation.Application.Contracts.Persistence;
using MotorReparation.Application.Contracts.Services;
using MotorReparation.Domain;

namespace MotorReparation.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository TicketRepository)
        {
            _ticketRepository = TicketRepository;
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
            return await _ticketRepository.GetByIdAsync(id);
        }
    }
}
