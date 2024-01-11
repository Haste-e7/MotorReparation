using System.ComponentModel.DataAnnotations.Schema;

namespace MotorReparation.Domain
{
    public class PartUnit:EntityBase
    {
        [ForeignKey("Ticket")]
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int PartId { get; set; } //Part table
        public double Price { get; set; }
        public double Quantity { get; set; }
    }
}
