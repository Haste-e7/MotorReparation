using MotorReparation.Application.Persistence;
using MotorReparation.Domain;

namespace MotorReparation.Infrastructure.Repositories
{
    public class BasketRepository : RepositoryBase<Basket>, IBasketRepository
    {
        public BasketRepository(MotorReparationDbContext dbContext) : base(dbContext)
        {
        }

    }
}
