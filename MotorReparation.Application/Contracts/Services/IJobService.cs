using MotorReparation.Domain;

namespace MotorReparation.Application.Contracts.Services
{
    public interface IJobService
    {
        Task<IReadOnlyList<Job>> GetAllJobsAsync();
        Task<Job> GetJobByIdAsync(int id);
        Task<Job> CreateJobAsync(Job Job);
        Task<Job> UpdateJobAsync(Job Job);
        Task<Job> DeleteJobAsync(int id);
    }
}
