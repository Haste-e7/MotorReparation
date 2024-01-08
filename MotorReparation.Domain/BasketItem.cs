using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorReparation.Domain
{
    public class BasketItem: EntityBase
    {
        public int BasketId { get; set; }
        public Basket? Basket { get; set; }
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public int Quantity { get; set; }
    }
}
