namespace MotorReparation.Domain
{
    public class Ticket : EntityBase
    {
        public int BasketId { get; set; }
        public Basket? Basket { get; set; }
        public int JobId { get; set; }
        public Job? Job { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int AssignedBay { get; set; } //quicklube only
        public int Quantity { get; set; } = 1;
        public ICollection<LaborUnit> LaborUnits { get; set; } = new List<LaborUnit>();
        public ICollection<PartUnit> PartUnits { get; set; } = new List<PartUnit>();

    }
}
