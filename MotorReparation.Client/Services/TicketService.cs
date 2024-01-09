using MotorReparation.Client.Services.IServices;
using MotorReparation.Domain;
using MotorReparation.Models.DTOs;
using Newtonsoft.Json;

namespace MotorReparation.Client.Services
{
    public class TicketService : ITicketService
    {
        private readonly HttpClient _client;
        public TicketService(HttpClient client)
        {
            _client = client;
        }
        public async Task<Ticket> GetTicketDetails(int id)
        {
            var response = await _client.GetAsync($"api/ticket/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var ticket = JsonConvert.DeserializeObject<Ticket>(content);
                return ticket;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }

        }

        public async Task<IEnumerable<Ticket>> GetAllTickets()
        {
            var response = await _client.GetAsync($"api/ticket");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var tickets = JsonConvert.DeserializeObject<IEnumerable<Ticket>>(content);
                return tickets;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }

        }
    }
}
