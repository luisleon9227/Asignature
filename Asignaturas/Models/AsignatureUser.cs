using Asignaturas.Enums;

namespace Asignaturas.Models
{
    public class AsignatureUser
    {
        //[Key]
        public Guid AsignatureUserId { get; set; }
        //[ForeignKey("UserId")]
        public Guid UserId { get; set; }
        //[Required]
        //[MaxLength(50)]
        public string NameAsignature { get; set; }

        public AreaTypes AreaTypes { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual User User { get; set; }
        //[NotMapped]
        public string Detail { get; set; }
    }
}
