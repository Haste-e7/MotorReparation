using System.ComponentModel.DataAnnotations.Schema;

namespace MotorReparation.Domain
{
    public class LaborUnit : EntityBase
    {
        [ForeignKey("Ticket")]
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        [ForeignKey("Employee")]
        public string EmployeeId { get; set; }
        public AppUser? Employee { get; set; }
        public double LaborRate { get; set; }
        public double Hour { get; set; }
    }
}
