using System.ComponentModel.DataAnnotations.Schema;

namespace MotorReparation.Domain
{
    public abstract class EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public  string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set;}

        public EntityBase()
        {
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;
            CreatedBy = "1";
            LastModifiedBy = "1";
        }
    }
}
