using MotorReparation.Application.Contracts.Persistence;
using MotorReparation.Domain;

namespace MotorReparation.Infrastructure.Repositories
{
    public class JobRepository : RepositoryBase<Job>, IJobRepository
    {
        public JobRepository(MotorReparationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
