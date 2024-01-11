using MotorReparation.Domain;

namespace MotorReparation.Client.Services.IServices
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetAllTickets(int basketId);
        Task<Ticket> GetTicketDetails(int id);
        Task<IEnumerable<Ticket>> GetAllTicketsByBasketId(int basketId);
        Task<string> CreateTicket(Ticket ticket);
        Task<string> UpdateTicket(Ticket ticket);
    }
}
