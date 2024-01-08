using MotorReparation.Application.Persistence;
using MotorReparation.Domain;

namespace MotorReparation.Infrastructure.Repositories
{
    public class BasketItemRepository : RepositoryBase<BasketItem>, IBasketItemRepository
    {
        public BasketItemRepository(MotorReparationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
