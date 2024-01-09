using MotorReparation.Domain;

namespace MotorReparation.Application.Contracts.Services
{
    public interface ITicketService
    {
        Task<IReadOnlyList<Ticket>> GetAllTicketsAsync();
        Task<Ticket> GetTicketByIdAsync(int id);
        Task<IReadOnlyList<Ticket>> GetAllTicketsByBasketIdAsync(int basketId);
    }
}
