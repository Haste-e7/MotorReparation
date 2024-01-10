using MotorReparation.Client.Services.IServices;
using MotorReparation.Domain;
using MotorReparation.Models.DTOs;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MotorReparation.Client.Services
{
    public class JobService : IJobService
    {
        private readonly HttpClient _client;
        public JobService(HttpClient client)
        {
            _client = client;
        }
        public async Task<Job> GetJobDetails(int id)
        {
            var response = await _client.GetAsync($"api/job/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var job = JsonConvert.DeserializeObject<Job>(content);
                return job;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }

        }

        public async Task<IEnumerable<Job>> GetAllJobs()
        {
            var response = await _client.GetAsync($"api/job");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var jobs = JsonConvert.DeserializeObject<IEnumerable<Job>>(content);
                return jobs;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }

        }

        public async Task<string> CreateJob(Job job)
        {
            var payload = JsonContent.Create(job);
            var response = await _client.PostAsync($"api/job", payload);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return content;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<string> UpdateJob(Job job)
        {
            var payload = JsonContent.Create(job);
            var response = await _client.PutAsync($"api/job/{job.Id}", payload);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }
    }
}
