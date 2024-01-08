namespace MotorReparation.Domain
{
    public class BasketItem: EntityBase
    {
        public int BasketId { get; set; }
        public Basket? Basket { get; set; }
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
