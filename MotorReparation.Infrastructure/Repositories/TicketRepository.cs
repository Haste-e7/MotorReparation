using MotorReparation.Application.Contracts.Persistence;
using MotorReparation.Domain;

namespace MotorReparation.Infrastructure.Repositories
{
    public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
    {
        public TicketRepository(MotorReparationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
