using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MotorReparation.Domain;

namespace MotorReparation.Infrastructure
{
    public class MotorReparationDbContext : IdentityDbContext<AppUser>
    {
        public MotorReparationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
