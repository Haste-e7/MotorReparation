using MotorReparation.Domain;

namespace MotorReparation.Application.Contracts.Services
{
    public interface IBasketService
    {
        Task<IReadOnlyList<Basket>> GetAllBasketsAsync();
        Task<Basket> GetBasketByIdAsync(int id);
        Task<int> CreateBasketAsync(Basket basket);
        Task<int> UpdateBasketAsync(Basket basket);
        Task<int> DeleteBasketAsync(int id);
    }
}
