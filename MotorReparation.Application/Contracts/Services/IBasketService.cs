using MotorReparation.Domain;

namespace MotorReparation.Application.Contracts.Services
{
    public interface IBasketService
    {
        Task<IReadOnlyList<Basket>> GetAllBasketsAsync();
        Task<Basket> GetBasketByIdAsync(int id);
        Task<Basket> CreateBasketAsync(Basket basket);
        Task<Basket> UpdateBasketAsync(Basket basket);
        Task<Basket> DeleteBasketAsync(int id);
    }
}
