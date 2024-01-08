using Microsoft.AspNetCore.Identity;

namespace MotorReparation.Domain
{
    public class AppUser : IdentityUser
    {
        public string? DisplayName { get; set; }
        public int BasketId { get; set; }
        public Basket? Basket { get; set; }
    }
}
