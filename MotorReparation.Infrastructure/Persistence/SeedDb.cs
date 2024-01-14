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
            if (!(userManager.Users.Any() && context.Jobs.Any()
                && context.Roles.Any(x => x.Name == StringDefinition.Role_Admin)))
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
                        DisplayName = "Employee1",
                        UserName = "employee1",
                        Email = "employee1@test.com"
                    },
                    new AppUser
                    {
                        Id = "4",
                        DisplayName = "Employee2",
                        UserName = "employee2",
                        Email = "employee2@test.com"
                    },
                    new AppUser
                    {
                        Id = "5",
                        DisplayName = "Employee3",
                        UserName = "employee3",
                        Email = "employee3@test.com"
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

                //admin
                var admin = context.Users.FirstOrDefault(u => u.Email == "admin@test.com");
                userManager.AddToRoleAsync(admin, StringDefinition.Role_Admin).GetAwaiter().GetResult();

                //employees
                var employee1 = context.Users.FirstOrDefault(u => u.Email == "employee1@test.com");
                userManager.AddToRoleAsync(employee1, StringDefinition.Role_Employee).GetAwaiter().GetResult();

                var employee2 = context.Users.FirstOrDefault(u => u.Email == "employee2@test.com");
                userManager.AddToRoleAsync(employee2, StringDefinition.Role_Employee).GetAwaiter().GetResult();

                var employee3 = context.Users.FirstOrDefault(u => u.Email == "employee3@test.com");
                userManager.AddToRoleAsync(employee3, StringDefinition.Role_Employee).GetAwaiter().GetResult();

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

                await context.SaveChangesAsync();
            }
        }
    }
}
