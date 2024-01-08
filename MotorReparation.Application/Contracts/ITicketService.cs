using MotorReparation.Domain;

namespace MotorReparation.Application.Contracts
{
    public interface ITicketService
    {
        Task<IReadOnlyList<Ticket>> GetAllTicketsAsync();
        Task<Ticket> GetTicketByIdAsync(int id);
    }
}
