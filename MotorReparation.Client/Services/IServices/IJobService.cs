using MotorReparation.Domain;

namespace MotorReparation.Client.Services.IServices
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAllJobs();
        Task<Job> GetJobDetails(int id);
        Task<string> CreateJob(Job ticket);
        Task<string> UpdateJob(Job ticket);
    }
}
