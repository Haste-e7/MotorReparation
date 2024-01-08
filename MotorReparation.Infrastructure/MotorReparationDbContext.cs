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
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Basket>()
                .HasOne(b => b.Customer)
                .WithOne(u => u.Basket)
                .HasForeignKey<Basket>(b => b.CustomerId);

            builder.Entity<BasketItem>(b =>
            {
                b.HasOne(bi => bi.Basket)
                    .WithMany(b => b.BasketItems)
                    .HasForeignKey(bi => bi.BasketId);

                b.HasOne(bi => bi.Ticket)
                    .WithMany(t => t.BasketItems)
                    .HasForeignKey(bi => bi.TicketId);
            });
        }
    }
}
