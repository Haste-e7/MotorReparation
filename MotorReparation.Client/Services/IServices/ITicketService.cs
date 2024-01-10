using MotorReparation.Domain;

namespace MotorReparation.Client.Services.IServices
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetAllTickets();
        Task<Ticket> GetTicketDetails(int id);
        Task<string> CreateTicket(Ticket ticket);
        Task<string> UpdateTicket(Ticket ticket);
    }
}
