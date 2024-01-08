using MotorReparation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorReparation.Application.Persistence
{
    public interface ITicketRepository : IAsyncRepository<Ticket>
    {

    }
}
