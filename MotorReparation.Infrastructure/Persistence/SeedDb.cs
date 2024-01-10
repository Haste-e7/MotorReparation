using Microsoft.AspNetCore.Identity;
using MotorReparation.Domain;

namespace MotorReparation.Infrastructure.Persistence
{
    public class SeedDb
    {
        public static async Task SeedData(MotorReparationDbContext context, 
            UserManager<AppUser> userManager, 
            RoleManager<IdentityRole> _roleManager)
        {
            if ( !(userManager.Users.Any() && context.Jobs.Any() 
                && context.Roles.Any(x => x.Name == StringDefinition.Role_Admin)) )
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Id = "1",
                        DisplayName = "Admin",
                        UserName = "admin",
                        Email = "admin@test.com",
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

                /*var basket = new Basket()
                {
                    Id = 1,
                    CustomerId = "1",
                    Tickets = new List<Ticket>
                    {
                        new Ticket
                        {
                            Id=1,
                            BasketId = 1,
                            JobId = 1,
                            Title = "Quick repair",
                            Description = "Quick repair sth",
                            Quantity = 1,
                            AssignedBay = 1,
                            Status = StringDefinition.StatusDone,
                        },
                        new Ticket
                        {
                            Id=2,
                            BasketId = 1,
                            JobId = 2,
                            Title = "Lengthy repair",
                            Description = "Lengthy Job",
                            Quantity = 1,
                            Status = StringDefinition.StatusInProcess,
                        },
                        new Ticket
                        {
                            Id=3,
                            BasketId = 1,
                            JobId = 3,
                            Title = "Lengthy repair",
                            Description = "Lengthy Job",
                            Quantity = 1,
                            Status = StringDefinition.StatusInProcess,
                        }
                    }
                };*/

                var Jobs = new List<Job>
                {
                    new Job
                    {
                        Id = 1,
                        Title = "Change oil",
                        Description = "Change new oil",
                        JobType = StringDefinition.TypeQuickLube,
                        Price = 200,

                    },
                    new Job
                    {
                        Id = 2,
                        Title = "Change engine",
                        Description = "Change new engine",
                        JobType = StringDefinition.TypeRepair,
                        Price = 150,
                    },
                    new Job
                    {
                        Id = 3,
                        Title = "Fix door",
                        Description = "Fix front door",
                        JobType = StringDefinition.TypeRepair,
                        Price = 100,
                    }
                };
                await context.AddRangeAsync(Jobs);
                //await context.AddRangeAsync(basket);

                await context.SaveChangesAsync();
            }
        }
    }
}
