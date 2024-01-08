using MotorReparation.Domain;

namespace MotorReparation.Application.Contracts
{
    public interface IBasketService
    {
        Task<IReadOnlyList<Basket>> GetAllBasketsAsync();
        Task<Basket> GetBasketByIdAsync(int id);
        Task<Basket> CreateBasketAsync(string userId);
        Task<Basket> UpdateBasketAsync(string userId);
        Task<Basket> DeleteBasketAsync(string userId);
    }
}
