namespace MotorReparation.Domain
{
    public class Ticket: EntityBase
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? TicketType { get; set; }
        public int AssignedBay { get; set; }
    }
}
