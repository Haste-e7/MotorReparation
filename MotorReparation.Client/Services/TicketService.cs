﻿using MotorReparation.Client.Services.IServices;
using MotorReparation.Domain;
using MotorReparation.Models.DTOs;
using Newtonsoft.Json;
using System.Net.Http.Json;

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

        public async Task<IEnumerable<Ticket>> GetAllTickets(int basketId)
        {
            var response = await _client.GetAsync($"api/Ticket?basketId={basketId}");
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
        public async Task<IEnumerable<Ticket>> GetAllTicketsByBasketId(int basketId)
        {
            var response = await _client.GetAsync($"api/basket/GetAllTicketsByBasketIdAsync?basketId={basketId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<Ticket>>(content); ;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }
        public async Task<string> CreateTicket(Ticket ticket)
        {
            var response = await _client.PostAsJsonAsync($"api/appuser/CreateUserTicket?userId={ticket.CreatedBy}", ticket);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                
                return content;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<string> UpdateTicket(Ticket ticket)
        {
            var response = await _client.PutAsJsonAsync($"api/ticket", ticket);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return content;
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
