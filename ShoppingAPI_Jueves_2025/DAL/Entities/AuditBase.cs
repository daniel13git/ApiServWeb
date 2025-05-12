using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_Jueves_2025.DAL.Entities
{
    public class AuditBase
    {
        [Key]
        [Required]
        public virtual Guid Id{ get; set; } // PK de las tablas
        public virtual DateTime? CreatedDate { get; set; } // guarda sus nuevos datos con su fecha
        public virtual DateTime? ModifiedDate { get; set; } // guarda los registros que se modificó con su fecha

    }
}
