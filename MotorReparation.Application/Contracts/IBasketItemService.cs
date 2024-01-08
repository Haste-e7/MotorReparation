using MotorReparation.Domain;

namespace MotorReparation.Application.Contracts
{
    public interface IBasketItemService
    {
        Task<IReadOnlyList<BasketItem>> GetAllBasketItemsAsync();
        Task<IReadOnlyList<BasketItem>> GetAllBasketItemsByBasketIdAsync(int basketId);
        Task<BasketItem> CreateBasketItemAsync(BasketItem basketItem);
        Task<BasketItem> UpdateBasketItemAsync(BasketItem basketItem);
        Task<BasketItem> DeleteBasketItemAsync(int id);
    }
}
