namespace MotorReparation.Domain
{
    public class Basket: EntityBase
    {
        public string? CustomerId { get; set; }
        public AppUser? Customer { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}
