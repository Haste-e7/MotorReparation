using MotorReparation.Application.Contracts.Persistence;
using MotorReparation.Application.Contracts.Services;
using MotorReparation.Domain;

namespace MotorReparation.Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly ITicketRepository _ticketRepository;
        public BasketService(IBasketRepository basketRepository, ITicketRepository TicketRepository) 
        { 
            _basketRepository = basketRepository;
            _ticketRepository = TicketRepository;
        }

        public async Task<IReadOnlyList<Basket>> GetAllBasketsAsync()
        {
            return await _basketRepository.GetAllAsync();
        }

        public async Task<Basket> GetBasketByIdAsync(int id)
        {

            var basket = await _basketRepository.GetByIdAsync(id);
            var Tickets = await _ticketRepository.GetAsync(t => t.BasketId == id, includeProperties: t => t.Job);
            basket.Tickets = Tickets.ToList();

            return basket;
        }

        public async Task<Basket> CreateBasketAsync(Basket basket)
        {
            return await _basketRepository.AddAsync(basket);
        }

        public async Task<Basket> UpdateBasketAsync(Basket basket)
        {

            throw new NotImplementedException();
        }

        public async Task<Basket> DeleteBasketAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
