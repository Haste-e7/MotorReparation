namespace MotorReparation.Domain
{
    public class Job : EntityBase
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? JobType { get; set; }
    }
}
