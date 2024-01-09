using MotorReparation.Application.Contracts.Persistence;
using MotorReparation.Application.Contracts.Services;
using MotorReparation.Domain;

namespace MotorReparation.Application.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        public JobService(IJobRepository JobRepository)
        {
            _jobRepository = JobRepository;
        }

        public async Task<IReadOnlyList<Job>> GetAllJobsAsync()
        {
            return await _jobRepository.GetAllAsync();
        }

        public async Task<Job> GetJobByIdAsync(int id)
        {
            return await _jobRepository.GetByIdAsync(id);
        }

        Task<Job> IJobService.CreateJobAsync(Job Job)
        {
            throw new NotImplementedException();
        }

        Task<Job> IJobService.DeleteJobAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Job> IJobService.UpdateJobAsync(Job Job)
        {
            throw new NotImplementedException();
        }
    }
}
