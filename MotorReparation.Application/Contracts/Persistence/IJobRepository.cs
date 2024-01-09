using MotorReparation.Domain;

namespace MotorReparation.Application.Contracts.Persistence
{
    public interface IJobRepository: IAsyncRepository<Job>
    {
    }
}
