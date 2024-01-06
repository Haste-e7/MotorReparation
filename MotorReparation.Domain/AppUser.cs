using Microsoft.AspNetCore.Identity;

namespace MotorReparation.Domain
{
    public class AppUser : IdentityUser
    {
        public string? DisplayName { get; set; }
    }
}
