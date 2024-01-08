using MotorReparation.Application.Contracts;
using MotorReparation.Application.Persistence;
using MotorReparation.Domain;

namespace MotorReparation.Application.Services
{
    public class BasketItemService : IBasketItemService
    {
        private readonly IBasketItemRepository _basketItemRepository;
        public BasketItemService(IBasketItemRepository basketItemRepository)
        {
            _basketItemRepository = basketItemRepository;
        }
        public async Task<BasketItem> CreateBasketItemAsync(BasketItem basketItem)
        {
            return await _basketItemRepository.AddAsync(basketItem);
        }

        public Task<BasketItem> DeleteBasketItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<BasketItem>> GetAllBasketItemsAsync()
        {
            return await _basketItemRepository.GetAllAsync();
        }

        public async Task<IReadOnlyList<BasketItem>> GetAllBasketItemsByBasketIdAsync(int basketId)
        {
            var basketItems = await _basketItemRepository.GetAsync(bi => bi.BasketId == basketId);
            return basketItems;
        }

        public Task<BasketItem> UpdateBasketItemAsync(BasketItem basketItem)
        {
            throw new NotImplementedException();
        }
    }
}
