using Asignaturas.Enums;
using System.ComponentModel.DataAnnotations;

namespace Asignaturas.Models
{
    public class User
    {
        //[Key]
        public Guid UserId { get; set; }
        //[Required]
        [MaxLength(50)]
        public string Name { get; set; }
        //[Required]
        //[MaxLength(100)]
        public string Email { get; set; }
        public IdentificationType IdentificationType { get; set; }
        public int IdentificationNumber { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<AsignatureUser> AsignatureUsers { get; set; }

    }
}
