using Microsoft.AspNetCore.Identity;
using MotorReparation.Domain;
using System.Net.Sockets;

namespace MotorReparation.Infrastructure.Persistence
{
    public class SeedDb
    {
        public static async Task SeedData(MotorReparationDbContext context, 
            UserManager<AppUser> userManager, 
            RoleManager<IdentityRole> _roleManager)
        {
            if ( !(userManager.Users.Any() && context.Tickets.Any() && context.Roles.Any(x => x.Name == StringDefinition.Role_Admin)) )
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Id = "1",
                        DisplayName = "Admin",
                        UserName = "admin",
                        Email = "admin@test.com",
                        BasketId = 1,
                    },
                    new AppUser
                    {
                        Id = "2",
                        DisplayName = "Employee",
                        UserName = "employee",
                        Email = "employee@test.com"
                    },
                    new AppUser
                    {
                        Id = "3",
                        DisplayName = "Customer",
                        UserName = "customer",
                        Email = "customer@test.com"
                    },
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }

                _roleManager.CreateAsync(new IdentityRole(StringDefinition.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(StringDefinition.Role_Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(StringDefinition.Role_Employee)).GetAwaiter().GetResult();

                var admin = context.Users.FirstOrDefault(u => u.Email == "admin@test.com");
                userManager.AddToRoleAsync(admin, StringDefinition.Role_Admin).GetAwaiter().GetResult();

                var basket = new Basket()
                {
                    Id = 1,
                    CustomerId = "1",
                    BasketItems = new List<BasketItem>
                    {
                        new BasketItem
                        {
                            BasketId = 1,
                            TicketId = 1,
                            Quantity = 1,
                        },
                        new BasketItem
                        {
                            BasketId = 2,
                            TicketId = 2,
                            Quantity = 1,
                        },
                        new BasketItem
                        {
                            BasketId = 3,
                            TicketId = 3,
                            Quantity = 1,
                        }
                    }
                };

                var tickets = new List<Ticket>
                {
                    new Ticket
                    {
                        Title = "Change oil",
                        Description = "Change new oil",
                        Status = StringDefinition.StatusPending,
                        TicketType = StringDefinition.TypeQuickLube,
                        AssignedBay = 1
                    },
                    new Ticket
                    {
                        Title = "Change engine",
                        Description = "Change new engine",
                        Status = StringDefinition.StatusDone,
                        TicketType = StringDefinition.TypeRepair,
                        AssignedBay = 1
                    },
                    new Ticket
                    {
                        Title = "Fix door",
                        Description = "Fix door",
                        Status = StringDefinition.StatusInProcess,
                        TicketType = StringDefinition.TypeRepair,
                        AssignedBay = 2
                    }
                };
                await context.AddRangeAsync(tickets);
                await context.AddRangeAsync(basket);

                await context.SaveChangesAsync();
            }
        }
    }
}
