using MotorReparation.Application.Contracts;
using MotorReparation.Application.Persistence;
using MotorReparation.Domain;

namespace MotorReparation.Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        public BasketService(IBasketRepository basketRepository) 
        { 
            _basketRepository = basketRepository;
        }

        public async Task<IReadOnlyList<Basket>> GetAllBasketsAsync()
        {
            return await _basketRepository.GetAllAsync();
        }

        public async Task<Basket> GetBasketByIdAsync(int id)
        {
            return await _basketRepository.GetByIdAsync(id);
        }

        public async Task<Basket> CreateBasketAsync(string userId)
        {

            var basket = new Basket()
            {
                CustomerId = userId,
            };

            return await _basketRepository.AddAsync(basket);
        }

        public async Task<Basket> UpdateBasketAsync(string userId)
        {

            throw new NotImplementedException();
        }

        public async Task<Basket> DeleteBasketAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
